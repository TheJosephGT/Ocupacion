using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

public class PrestamosBLL{

        private Contexto _contexto;

        public PrestamosBLL(Contexto contexto)
        {
            _contexto = contexto;
        }

        public bool Existe(int prestamoId)
        {
            return _contexto.Prestamos.Any(o => o.PrestamoId == prestamoId);
        }

        private bool Insertar(Prestamos prestamo)
        {
            AumentarBalance(prestamo);
            _contexto.Prestamos.Add(prestamo);
            return _contexto.SaveChanges() > 0;
        }

        private bool Modificar(Prestamos prestamo)
        {
            _contexto.Entry(prestamo).State = EntityState.Modified;
            return _contexto.SaveChanges() > 0;
        }

        public bool Guardar(Prestamos prestamo)
        {
            if (!Existe(prestamo.PrestamoId))
                return this.Insertar(prestamo);
            else
                return this.Modificar(prestamo);
        }



        public bool Eliminar(Prestamos prestamo)
        {
            _contexto.Entry(prestamo).State = EntityState.Deleted;
            return  _contexto.SaveChanges() > 0;
        }

        public Prestamos? Buscar(int prestamoId)
        {
            return _contexto.Prestamos.Where(o => o.PrestamoId == prestamoId).AsNoTracking().SingleOrDefault();
        }

        public List<Prestamos> GetList(Expression<Func<Prestamos, bool>> criterio)
        {
            return _contexto.Prestamos.AsNoTracking().Where(criterio).ToList();
        }

        private void AumentarBalance(Prestamos prestamos)
        {
            prestamos.Balance = prestamos.Monto;
            var persona = _contexto.Personas.Find(prestamos.PersonaId);
            if(persona != null){
                persona.Balance = persona.Balance + prestamos.Monto;
                _contexto.Entry(persona).State = EntityState.Modified;
                _contexto.SaveChanges();
            } 
        }


}