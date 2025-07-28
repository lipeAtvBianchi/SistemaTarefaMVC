using Microsoft.AspNetCore.Mvc;
using sistemaAgendamento.Context;
using sistemaAgendamento.Models;

namespace sistemaAgendamento.Controllers
{
    public class TarefaController : Controller
    {
        private readonly TarefaContext _context;

        public TarefaController(TarefaContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var lista = _context.Tarefas.ToList();
            return View(lista);
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Details(int id)
        {
            var tarefa = _context.Tarefas.Find(id);
            return View(tarefa);
        }

        public IActionResult Edit(int id)
        {
            var tarefa = _context.Tarefas.Find(id);
            return View(tarefa);
        }

        public IActionResult Delete(int id)
        {
            var tarefa = _context.Tarefas.Find(id);
            return View(tarefa);
        }

        [HttpPost]
        public IActionResult Create(TarefaModel tarefa)
        {
            if (ModelState.IsValid)
            {
                var tarefaBanco = new TarefaModel
                {
                    Titulo = tarefa.Titulo,
                    Descricao = tarefa.Descricao,
                    Data = tarefa.Data,
                    Status = tarefa.Status ? true : false
                };

                tarefaBanco.Data = DateTime.SpecifyKind(tarefa.Data, DateTimeKind.Utc);

                _context.Tarefas.Add(tarefaBanco);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));

            }
            return View();
        }

        [HttpPost]
        public IActionResult UpdateStatus(int id, bool status)
        {
            var tarefa = _context.Tarefas.Find(id);

            if (tarefa == null)
            {
                return NotFound();
            }

            tarefa.Status = status;
            _context.Tarefas.Update(tarefa);
            _context.SaveChanges();

            TempData["Mensagem"] = "Status da tarefa atualizado com sucesso!";
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Edit(TarefaModel tarefa)
        {
            var tarefaAtualizada = _context.Tarefas.Find(tarefa.Id);
            if (tarefa == null) return NotFound();

            tarefaAtualizada.Titulo = tarefa.Titulo;
            tarefaAtualizada.Descricao = tarefa.Descricao;
            tarefaAtualizada.Data = DateTime.SpecifyKind(tarefa.Data, DateTimeKind.Utc);
            tarefaAtualizada.Status = tarefa.Status;

            _context.Tarefas.Update(tarefaAtualizada);
            _context.SaveChanges();

            TempData["Mensagem"] = "Tarefa atualizada com sucesso!";
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            var tarefa = _context.Tarefas.Find(id);
            if (tarefa == null) return NotFound();

            _context.Tarefas.Remove(tarefa);
            _context.SaveChanges();

            TempData["Mensagem"] = "Tarefa Excluida com sucesso!";

            return RedirectToAction(nameof(Index));
        }
    }
}