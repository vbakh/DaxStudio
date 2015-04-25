﻿
using DaxStudio.QueryTrace.Interfaces;
using Microsoft.AnalysisServices;
//using AMOTabular;
//using AMOTabular.AmoWrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaxStudio.QueryTrace
{
    public static class QueryTraceEngineFactory
    {
        public static IQueryTrace CreateLocal(ADOTabular.ADOTabularConnection connection, List<TraceEventClass> events) {
            var dsEvents = events.Select(e => (DaxStudioTraceEventClass)e).ToList();
            return new QueryTraceEngine(connection.ConnectionString, connection.Type, connection.SessionId, dsEvents); 
        }
        public static IQueryTrace CreateRemote(ADOTabular.ADOTabularConnection connection, List<TraceEventClass> events, int port) {
            var dsEvents = events.Select(e => (DaxStudioTraceEventClass)e).ToList();
            return new RemoteQueryTraceEngine(connection.ConnectionString,connection.Type,connection.SessionId, dsEvents, port);
        }
    }
}