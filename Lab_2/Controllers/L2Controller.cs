using Lab_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.Json;
using System.Web.Http;

namespace Lab_2.Controllers
{
    public class L2Controller : ApiController
    {
        static int _result = 0;

        [HttpGet]
        public string Get()
        {
            int stackVal = GoodStack._stack.Count == 0 ? 0 : GoodStack._stack.Peek();
            return JsonSerializer.Serialize(new { result = _result + stackVal });
        }

        [HttpPost]
        public string Post([FromBody]int result)
        {
            _result += result;
            return JsonSerializer.Serialize(new { result = _result });
        }

        [HttpPut]
        public string Put([FromBody]int add)
        {
            GoodStack._stack.Push(add);
            return JsonSerializer.Serialize(new { result = GoodStack._stack });
        }

        [HttpDelete]
        public string Delete()
        {
            if(GoodStack._stack.Count != 0)
            {
                GoodStack._stack.Pop();
            }
            return JsonSerializer.Serialize(new { result = GoodStack._stack });
        }
    }
}