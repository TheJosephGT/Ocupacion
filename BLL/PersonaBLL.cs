using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

public class PersonaBLL
{

    private Contexto _contexto;

    public PersonaBLL(Contexto contexto)
    {
        _contexto = contexto;
    }

    public bool Existe(int personaId)
    {
        return _contexto.Persona.Any(o => o.PersonaId == personaId);
    }

    private bool Insertar(Persona persona)
    {
        _contexto.Persona.Add(persona);
        return _contexto.SaveChanges() > 0;
    }

    private bool Modificar(Persona persona)
    {
        _contexto.Entry(persona).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        return _contexto.SaveChanges() > 0;
    }

    public bool Guardar(Persona persona)
    {
        if (!Existe(persona.PersonaId))
            return this.Insertar(persona);
        else
            return this.Modificar(persona);
    }

    private bool Eliminar(Persona persona)
    {
        _contexto.Entry(persona).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
        return _contexto.SaveChanges() > 0;
    }

    public Persona? Buscar(int personaId)
    {
        return _contexto.Persona.Where(o => o.PersonaId == personaId).AsNoTracking().SingleOrDefault();
    }

    public List<Persona> GetList()
    {
        return _contexto.Persona.ToList();
    }
}