using System;
using System.Collections.Generic;
using System.Text;

namespace Tools.Connection.Database
{
    public class Command
    {
        private string _query;
        private bool _isStoredProcedure;
        private Dictionary<string, object> _parameters;

        public Command(string query, bool isStoredProcedure = false)
        {
            if (string.IsNullOrWhiteSpace(query))
            {
                throw new ArgumentNullException("Query can't be null!");
            }

            _query = query;
            _isStoredProcedure = isStoredProcedure;
            _parameters = new Dictionary<string, object>();
        }

        public string Query
        {
            get
            {
                return _query;
            }
        }

        public bool IsStoredProcedure
        {
            get
            {
                return _isStoredProcedure;
            }
        }

        public Dictionary<string, object> Parameters
        {
            get
            {
                return _parameters;
            }
        }

        public void AddParameter(string parameterName, object value)
        {
            if (string.IsNullOrWhiteSpace(parameterName))
            {
                throw new ArgumentNullException("Parameter can't be null!");
            }

            if (_parameters.ContainsKey(parameterName))
            {
                throw new MissingMemberException("Parameter {0} already exists!", parameterName);
            }

            _parameters.Add(parameterName, value ?? DBNull.Value);
        }
    }
}
