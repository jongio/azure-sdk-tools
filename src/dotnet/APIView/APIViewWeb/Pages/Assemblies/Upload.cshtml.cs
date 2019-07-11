﻿using System.Threading.Tasks;
using APIViewWeb.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace APIViewWeb.Pages.Assemblies
{
    public class UploadModel : PageModel
    {
        private readonly BlobAssemblyRepository assemblyRepository;

        public UploadModel(BlobAssemblyRepository assemblyRepository)
        {
            this.assemblyRepository = assemblyRepository;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(IFormFile file)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (file.Length > 0)
            {
                AssemblyModel assemblyModel = new AssemblyModel(file.OpenReadStream(), file.FileName);
                await assemblyRepository.UploadAssemblyAsync(assemblyModel, file.FileName);
            }

            return RedirectToPage("./Index");
        }
    }
}