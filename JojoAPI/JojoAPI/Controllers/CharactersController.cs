using JojoAPI.Core.Interfaces;
using JojoAPI.Model;
using JojoAPI.Model.DTOs.Incoming;
using Microsoft.AspNetCore.Mvc;

namespace JojoAPI.Controllers
{
    [ApiController]
    [Route("api/characters")]
    public class CharactersController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        public CharactersController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        #region GET

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await unitOfWork.Characters.GetAll());
        }

        [HttpGet]
        [Route("{name}")]
        public async Task<IActionResult> GetByName(string name)
        {
            var character = await unitOfWork.Characters.GetByName(name);

            if (character == null) return NotFound();

            return Ok(character);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var character = await unitOfWork.Characters.GetById(id);

            if (character == null) return NotFound();

            return Ok(character);
        }

        [HttpGet]
        [Route("jojos")]
        public async Task<IActionResult> GetJojos()
        {
            var jojos = await GetCharacterBasedOnRole(Role.Jojo);
            return Ok(jojos);
        }

        [HttpGet]
        [Route("jobros")]
        public async Task<IActionResult> GetJobros()
        {
            var jobros = await GetCharacterBasedOnRole(Role.JoBro);
            return Ok(jobros);
        }

        [HttpGet]
        [Route("villains")]
        public async Task<IActionResult> GetVillains()
        {
            var villains = await GetCharacterBasedOnRole(Role.Villain);
            return Ok(villains);
        }

        private async Task<IEnumerable<Character>> GetCharacterBasedOnRole(Role role)
        {
            var characters = await unitOfWork.Characters.GetAll();
            characters = characters.Where(x => x.Role == role);

            return characters;
        }

        #endregion

        #region POST

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddCharacter(CharacterInDTO characterInDTO)
        {
            Stand? stand = null;

            var existentCharacter = await unitOfWork.Characters.GetByNameAndSurname(characterInDTO.Name
                , characterInDTO.Surname);

            var existentStand = await unitOfWork.Stands.GetById(characterInDTO.StandId);

            if (existentCharacter != null) return Conflict();

            if (existentStand != null) stand = existentStand;

            Character character = new Character()
            {
                Name = characterInDTO.Name,
                SeasonDebut = characterInDTO.SeasonDebut,
                Surname = characterInDTO.Surname,
                Stand = stand,
                Role = characterInDTO.Role
            };


            await unitOfWork.Characters.Add(character);
            await unitOfWork.CompleteAsync();
            
            return CreatedAtAction(nameof(GetById), new { id = character.Id }, character);
        }

        #endregion

        #region PUT

        [HttpPut]
        [Route("")]
        public async Task<IActionResult> UpdateCharacter(CharacterUpdateInDTO characterIn)
        {
            var existentCharacter = await unitOfWork.Characters.GetById(characterIn.Id);
            var existentStand = await unitOfWork.Stands.GetById(characterIn.StandId);

            Stand? stand = null;

            if (existentCharacter == null) return NotFound();
            if (existentStand != null) stand = existentStand;

            var character = new Character()
            {
                Id = characterIn.Id,
                Name = characterIn.Name,
                Role = characterIn.Role,
                SeasonDebut = characterIn.SeasonDebut,
                Surname = characterIn.Surname,
                Stand = stand,
            };

            await unitOfWork.Characters.Update(character);
            await unitOfWork.CompleteAsync();

            return NoContent();
        }

        #endregion

        #region DELETE

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteById(int id)
        {
            var character = await unitOfWork.Characters.GetById(id);

            if (character == null) return NotFound();

            await unitOfWork.Characters.Delete(character);
            await unitOfWork.CompleteAsync();

            return NoContent();
        }

        #endregion
    }
}
