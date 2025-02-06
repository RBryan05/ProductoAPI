using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductoAPI.DTOs;
using ProductoAPI.Models;

namespace ProductoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private ProductoContext _context;
        public ProductoController(ProductoContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<ProductoDTO>> Get()
        {
            return await _context.Productos
                .Select(p => new ProductoDTO
                {
                    Id = p.Id,
                    Nombre = p.Nombre,
                    Precio = p.Precio,
                    Stock = p.Stock
                })
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductoDTO>> GetById(int id)
        {
            var producto = await _context.Productos.FindAsync(id);
            if (producto == null)
            {
                return NotFound();
            }
            var ProductoDTO = new ProductoDTO
            {
                Id = producto.Id,
                Nombre = producto.Nombre,
                Precio = producto.Precio,
                Stock = producto.Stock
            };

            return Ok(ProductoDTO);
        }

        [HttpPost]
        public async Task<ActionResult> Post(ProductoInsertDTO productoDTO)
        {

            var producto = new Producto
            {
                Nombre = productoDTO.Nombre,
                Precio = productoDTO.Precio,
                Stock = productoDTO.Stock
            };

            _context.Productos.Add(producto);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = producto.Id }, null);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, ProductoUpdateDTO nuevoProductoDTO)
        {
            var producto = await _context.Productos.FindAsync(id);
            if (producto == null) 
            { 
                return NotFound(); 
            }

            producto.Nombre = nuevoProductoDTO.Nombre;
            producto.Precio = nuevoProductoDTO.Precio;
            producto.Stock = nuevoProductoDTO.Stock;

            _context.SaveChanges();
            var nuevoProducto = new ProductoDTO
            {
                Id = producto.Id,
                Nombre = producto.Nombre,
                Precio = producto.Precio,
                Stock = producto.Stock,
            };
            return Ok(nuevoProducto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var producto = await _context.Productos.FindAsync(id);
            if (producto == null)
            {
                return NotFound();
            }

            _context.Productos.Remove(producto);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}