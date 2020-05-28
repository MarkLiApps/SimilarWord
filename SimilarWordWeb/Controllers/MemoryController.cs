﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WordSimilarityLib;
using System.IO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SimilarWordWeb.Controllers
{
    [Route("api/[controller]")]
    public class MemoryController : Controller
    {
        string userId = "markli";
        string memoryMethod = "fib";

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<Word> Get()
        {
            WordDictionary wd = new WordDictionary();
            if (WordDictionary.WordList.Count() <= 0)
                wd.ReadFile(Path.Combine(Directory.GetCurrentDirectory(), @"data\WordSimilarityList.txt"));
            MemoryFibonacci memoryFib = new MemoryFibonacci(@"data\menory_" + memoryMethod + userId + ".txt");
            memoryFib.ReadMemoryLog();

            List<Word> result = memoryFib.getViewList(10);
            return result;
        }


        // GET api/<controller>/5
        [HttpGet("{count}")]
        public List<MemoryLogFibonacci> Get(string count)
        {
            try
            {
                WordDictionary wd = new WordDictionary();
                if (WordDictionary.WordList.Count() <= 0)
                    wd.ReadFile(Path.Combine(Directory.GetCurrentDirectory(), @"data\WordSimilarityList.txt"));

                MemoryFibonacci memoryFib = new MemoryFibonacci(@"data\menory_" + memoryMethod + userId + ".txt");
                memoryFib.ReadMemoryLog();

                List<MemoryLogFibonacci> result = new List<MemoryLogFibonacci>();
                int maxCount = Convert.ToInt32(count);
                for (int i = 0; i < maxCount && i < memoryFib.logList.Count; i++)
                    result.Add(memoryFib.logList[memoryFib.logList.Count - 1 - i]);

                return result;
            }
            catch (Exception ex)
            {
                MemoryLogFibonacci err = new MemoryLogFibonacci();
                err.name = "ERROR:" + ex.Message + ex.StackTrace;
                return new List<MemoryLogFibonacci>() { err };
            }
        }


        // POST api/<controller>
        [HttpPost]
        public string Post([FromBody] Word w)
        {
            return "Got ";
        }

        [HttpPut("{name}")]
        public string Put(string name, [FromBody]Word word)
        {
            try
            {
                int interval = word.viewInterval;
                MemoryFibonacci memoryList = new MemoryFibonacci(@"data\menory_"+memoryMethod+userId+".txt");
                int rt;
                if (interval <= -1) rt = memoryList.StartNewItem(name);
                else rt = memoryList.UpdateMemoryItem(word);
                if (rt < 0) return "ERROR:" + name + " has already record";
                return "OK";
            }
            catch (Exception ex)
            {
                return "ERROR:"+ ex.Message + ex.StackTrace;
            }

        }

        // DELETE api/<controller>/5
        [HttpDelete("{name}")]
        public string Delete(string name)
        {
            try
            {
                WordDictionary wd = new WordDictionary();
                if (WordDictionary.WordList.Count() <= 0)
                    wd.ReadFile(Path.Combine(Directory.GetCurrentDirectory(), @"data\WordSimilarityList.txt"));

                if (wd.DeleteWord(name)) return "OK";

                return "ERROR:"+ "failed to update";

            }
            catch (Exception ex)
            {
                return "ERROR:"+ ex.Message + ex.StackTrace;
            }
        }



        ////////////////////////////////////////////////////////////// end
    }
}
