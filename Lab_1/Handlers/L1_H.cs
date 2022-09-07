using System;
using System.Web;
using Lab_1.Entites;
using Json.Net;
using System.Collections.Generic;

namespace Lab_1.Handlers
{
    public class L1_H : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {
        public Result result = new Result();
        public bool IsReusable
        {
            get { return true; }
        }

        public void ProcessRequest(HttpContext context)
        {
            if(context.Request.HttpMethod == "DELETE")
            {
                Stack<int> temp = (Stack<int>)context.Session["stack"] ;
                temp.Pop();
                context.Session["stack"] = temp;
                context.Response.Write(JsonNet.Serialize(context.Session["stack"]));
            }
            if(context.Request.HttpMethod == "GET")
            {
                Stack<int> temp = (Stack<int>)context.Session["stack"];
                int sum;
                if (temp.Count == 0)
                {
                    sum = result.result;
                }
                else
                {
                    sum = result.result + temp.Peek();
                }
                string json = JsonNet.Serialize(JsonNet.Serialize(new Result(sum)));
                context.Response.Write(json);
            }
            if(context.Request.HttpMethod == "POST")
            {
                int bodyVar = int.Parse(context.Request.Form.Get("result"));
                result.result = bodyVar;
                string json = JsonNet.Serialize(result);
                context.Response.Write(json);
            }
            if(context.Request.HttpMethod == "PUT")
            {
                int bodyVar = int.Parse(context.Request.Form.Get("add"));
                Stack<int> temp = (Stack<int>)context.Session["stack"];
                temp.Push(bodyVar);
                context.Session["stack"] = temp;
                context.Response.Write(JsonNet.Serialize(context.Session["stack"]));
            }
        }
    }
}
