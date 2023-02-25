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
            var prestamoEncontrada = _contexto.Prestamos.Find(prestamo.PrestamoId);

            if(prestamoEncontrada != null){
                _contexto.Entry(prestamo).CurrentValues.SetValues(prestamo);
                return _contexto.SaveChanges() > 0;
            }

            return false;
        }

        public bool Guardar(Prestamos prestamo)
        {
            if (!Existe(prestamo.PrestamoId))
                return this.Insertar(prestamo);
            else
                return this.Modificar(prestamo);
        }



        public bool Eliminar(int prestamoId)
        {
            var prestamoEncontrada = _contexto.Prestamos.Where(o => o.PrestamoId == prestamoId).SingleOrDefault();
            if(prestamoEncontrada != null){
                _contexto.Entry(prestamoEncontrada).State = EntityState.Deleted;
                return  _contexto.SaveChanges() > 0;
            }

            return false;
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