using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

public class PersonasBLL
{

        private Contexto _contexto;

        public PersonasBLL(Contexto contexto)
        {
            _contexto = contexto;
        }

        public bool Existe(int personaId)
        {
            return _contexto.Personas.Any(o => o.PersonaId == personaId);
        }

        private bool Insertar(Personas persona)
        {
            _contexto.Personas.Add(persona);
            return _contexto.SaveChanges() > 0;
        }

        private bool Modificar(Personas persona)
        {
            var personaEncontrada = _contexto.Personas.Find(persona.PersonaId);

            if(personaEncontrada != null){
                _contexto.Entry(persona).CurrentValues.SetValues(persona);
                return _contexto.SaveChanges() > 0;
            }

            return false;
        }

        public bool Guardar(Personas persona)
        {
            if (!Existe(persona.PersonaId))
                return this.Insertar(persona);
            else
                return this.Modificar(persona);
        }

        public bool Eliminar(int personaId)
        {
            var personaEncontrada = _contexto.Personas.Where(o => o.PersonaId == personaId).SingleOrDefault();
            if(personaEncontrada != null){
                _contexto.Entry(personaEncontrada).State = EntityState.Deleted;
                return  _contexto.SaveChanges() > 0;
            }

            return false;
        }

        public Personas? Buscar(int personaId)
        {
            return _contexto.Personas.Where(o => o.PersonaId == personaId).AsNoTracking().SingleOrDefault();
        }

        public List<Personas> GetList(Expression<Func<Personas, bool>> criterio)
        {
            return _contexto.Personas.AsNoTracking().Where(criterio).ToList();
        }
}