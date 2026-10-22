using Microsoft.AspNetCore.Mvc;
using ClinicaVida.Web.Models;

namespace ClinicaVida.Web.Controllers;

public class EspecialidadesController : Controller
{
    // Action: Lista de Especialidades (usando a lista em memória com contagem de médicos)
    public IActionResult Index()
    {
        var contagem = new Dictionary<int, int>();

        foreach (var e in ClinicaEmMemoria.Especialidades)
        {
            contagem[e.Id] = ClinicaEmMemoria.Medicos.Count(m => m.EspecialidadeId == e.Id);
        }

        ViewBag.MedicosPorEspecialidade = contagem;

        return View(ClinicaEmMemoria.Especialidades);
    }

    // Action: Detalhes de uma Especialidade
    public IActionResult Details(int id)
    {
        var especialidade = ClinicaEmMemoria.Especialidades.FirstOrDefault(e => e.Id == id);
        
        if (especialidade is null)
        {
            return NotFound(); // 404: essa especialidade não existe na clínica
        }

        return View(especialidade);
    }
}