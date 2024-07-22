using APW.Service;
using APW.Models;
using Microsoft.AspNetCore.Mvc;

namespace AdvancedProgrammingWeb.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PlayerController(IPlayerService playerService) : ControllerBase
{
    private readonly IPlayerService _playerService = playerService;

    #region Tarea

    /*  5 Puntos.
          
        Título: 
        Como desarrollador, quiero corregir los endpoints del API
        para que realicen la funcion de acuerdo al metodo definido en conjunto
        con los metodos creados en el Servicio de PlayerService.

        Descripción:
        Como parte del desarrollo del sistema de gestión de equipos deportivos, 
        necesitamos implementar una funcionalidad que permita corregir los endpoints 
        del API para que realicen la funcion de acuerdo al metodo definido en conjunto
        con los metodos creados en el Servicio de PlayerService. Además, es 
        crucial corregir el valor de retorno para garantizar que sea el esperado.
        
        A modo de ayuda se le proporciono un codigo inicial comentado en cada metodo
        para indicarle como llamar a los metodos de la dependencia.

        Criterios de Aceptación:
        1. Corrigio los metodos/endpoints del API.
        2. El valor de retorno del metodo del API es el esperado.
        3. El profesor utilizara una prueba unitaria para verificar la funcionalidad.
        4. Si La prueba unitaria pasa exitosamente después de la implementación de la funcionalidad, tiene los puntos.
        5. Se ha realizado una revisión del código para garantizar la calidad y coherencia del mismo.
        6. La funcionalidad implementada se ha integrado correctamente con el API.
        7. De igual forma el resultado debe poder mostrarse en SwaggerUI.
    */

    // GET: api/<PlayerController>
    [HttpGet("single")]
    public Player GetSingle(string teamName)
    {
        //return _playerService.
        return null!;
    }

    [HttpGet("all")]
    public IEnumerable<Player> GetAll(string teamName)
    {
        return _playerService.GetAllPlayersByTeam(teamName);
        //return null;
    }

    [HttpGet("retired")]
    public IEnumerable<Player> GetRetired()
    {
        //return _playerService.
        return null!;
    }

    [HttpGet("oldest")]
    public IEnumerable<Player> GetOldest()
    {
        //return _playerService.
        return null!;
    }

    [HttpGet("youngest")]
    public Player GetYoungest()
    {
        //return _playerService.
        return null!;
    }

    #endregion
    
    // GET api/<PlayerController>/5
    [HttpGet("{id}")]
    public string Get(int id)
    {
        return "value";
    }

    // POST api/<PlayerController>
    [HttpPost]
    public void Post([FromBody] string value)
    {
    }

    // PUT api/<PlayerController>/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/<PlayerController>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }

}
