using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using lohran_mendes_DR4_AT_S2.Models;


public class ViewNotesModel: PageModel
{
    [BindProperty] // É o que permite o binding automático dos dados do formulário para a propriedade User
    public new required Anotacao Anotacao { get; set; }

    public List<Anotacao> Notas;

    public void OnGet()
    {
    }

    public IActionResult OnPost()
    {
        if (ModelState.IsValid)
        {
            Notas.Add(Anotacao);
            return RedirectToPage("/Users/Index");
        }

        return Page();
    }


}