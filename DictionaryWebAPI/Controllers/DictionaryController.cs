using DictionaryLab.Model;
using Microsoft.AspNetCore.Mvc;

namespace DictionaryWebAPI.Controllers;


[ApiController]
[Route("[controller]")]
public class DictionaryController
{
    private readonly IWordRepository _repository;

    public DictionaryController(IWordRepository repository)
    {
        _repository = repository;
    }
    
    [HttpGet] [Route("/get-words-with-same-root")]
    public async Task<List<WordDto>> GetSameRoot([FromQuery] string word)
    {
        return await _repository.SameRoot(word);

    }

    [HttpPost]
    [Route("/add-new-word")]
    public Task AddWordToDictionary([FromBody] WordDto w)
    {
        return _repository.AddNewWord(w);
    }

    [HttpGet]
    [Route("/show-all-words")]
    public async Task<List<WordDto>> GetWords()
    {
        return await _repository.GetAll();
    }
}