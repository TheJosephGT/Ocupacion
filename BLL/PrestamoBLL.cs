using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

public class PrestamoBLL{

    private Contexto _contexto;

    public PrestamoBLL(Contexto contexto)
    {
        _contexto = contexto;
    }

    public bool Existe(int PrestamoId)
    {
        return _contexto.Prestamo.Any(o => o.PrestamoId == PrestamoId);
    }

    private bool Insertar(Prestamo prestamo)
    {
        _contexto.Prestamo.Add(prestamo);
        return _contexto.SaveChanges() > 0;
    }

    private bool Modificar(Prestamo prestamo)
    {
        _contexto.Entry(prestamo).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        return _contexto.SaveChanges() > 0;
    }

    public bool Guardar(Prestamo prestamo)
    {
        if (!Existe(prestamo.PrestamoId))
            return this.Insertar(prestamo);
        else
            return this.Modificar(prestamo);
    }

    private bool Eliminar(Prestamo prestamo)
    {
        _contexto.Entry(prestamo).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
        return _contexto.SaveChanges() > 0;
    }

    public Prestamo? Buscar(int PrestamoId)
    {
        return _contexto.Prestamo.Where(o => o.PrestamoId == PrestamoId).AsNoTracking().SingleOrDefault();
    }

    public List<Prestamo> GetList()
    {
        return _contexto.Prestamo.ToList();
    }

}