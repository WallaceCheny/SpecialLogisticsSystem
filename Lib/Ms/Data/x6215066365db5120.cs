namespace Ms.Data
{
    using System;
    using System.Data;
    using System.Reflection;
    using System.Runtime.CompilerServices;

    internal class x6215066365db5120 : Ms.Data.IDataReader, IDisposable, System.Data.IDataReader, IDataRecord
    {
        private x42ec19f833cd5adc _x4d0d7a709bc49dc1;
        [CompilerGenerated]
        private System.Data.IDataReader xc5674d4e912e69d6;

        public x6215066365db5120(System.Data.IDataReader reader)
        {
            this.InnerReader = reader;
        }

        public void Close()
        {
            this.InnerReader.Close();
        }

        public void Dispose()
        {
            this.InnerReader.Dispose();
        }

        public bool GetBoolean(int i)
        {
            return this.InnerReader.GetBoolean(i);
        }

        public bool GetBoolean(string name)
        {
            return this.InnerReader.GetBoolean(this.GetOrdinal(name));
        }

        public byte GetByte(int i)
        {
            return this.InnerReader.GetByte(i);
        }

        public byte GetByte(string name)
        {
            return this.InnerReader.GetByte(this.GetOrdinal(name));
        }

        public long GetBytes(int i, long fieldOffset, byte[] buffer, int bufferoffset, int length)
        {
            return this.InnerReader.GetBytes(i, fieldOffset, buffer, bufferoffset, length);
        }

        public long GetBytes(string name, long fieldOffset, byte[] buffer, int bufferoffset, int length)
        {
            return this.InnerReader.GetBytes(this.GetOrdinal(name), fieldOffset, buffer, bufferoffset, length);
        }

        public char GetChar(int i)
        {
            return this.InnerReader.GetChar(i);
        }

        public char GetChar(string name)
        {
            return this.InnerReader.GetChar(this.GetOrdinal(name));
        }

        public long GetChars(int i, long fieldoffset, char[] buffer, int bufferoffset, int length)
        {
            return this.InnerReader.GetChars(i, fieldoffset, buffer, bufferoffset, length);
        }

        public long GetChars(string name, long fieldoffset, char[] buffer, int bufferoffset, int length)
        {
            return this.InnerReader.GetChars(this.GetOrdinal(name), fieldoffset, buffer, bufferoffset, length);
        }

        public System.Data.IDataReader GetData(int i)
        {
            return this.InnerReader.GetData(i);
        }

        public System.Data.IDataReader GetData(string name)
        {
            return this.InnerReader.GetData(this.GetOrdinal(name));
        }

        public string GetDataTypeName(int i)
        {
            return this.InnerReader.GetDataTypeName(i);
        }

        public string GetDataTypeName(string name)
        {
            return this.InnerReader.GetDataTypeName(this.GetOrdinal(name));
        }

        public DateTime GetDateTime(int i)
        {
            return this.InnerReader.GetDateTime(i);
        }

        public DateTime GetDateTime(string name)
        {
            return this.InnerReader.GetDateTime(this.GetOrdinal(name));
        }

        public decimal GetDecimal(int i)
        {
            return this.InnerReader.GetDecimal(i);
        }

        public decimal GetDecimal(string name)
        {
            return this.InnerReader.GetDecimal(this.GetOrdinal(name));
        }

        public double GetDouble(int i)
        {
            return this.InnerReader.GetDouble(i);
        }

        public double GetDouble(string name)
        {
            return this.InnerReader.GetDouble(this.GetOrdinal(name));
        }

        public Type GetFieldType(int i)
        {
            return this.InnerReader.GetFieldType(i);
        }

        public Type GetFieldType(string name)
        {
            return this.InnerReader.GetFieldType(this.GetOrdinal(name));
        }

        public float GetFloat(int i)
        {
            return this.InnerReader.GetFloat(i);
        }

        public float GetFloat(string name)
        {
            return this.InnerReader.GetFloat(this.GetOrdinal(name));
        }

        public Guid GetGuid(int i)
        {
            return this.InnerReader.GetGuid(i);
        }

        public Guid GetGuid(string name)
        {
            return this.InnerReader.GetGuid(this.GetOrdinal(name));
        }

        public short GetInt16(int i)
        {
            return this.InnerReader.GetInt16(i);
        }

        public short GetInt16(string name)
        {
            return this.InnerReader.GetInt16(this.GetOrdinal(name));
        }

        public int GetInt32(int i)
        {
            return this.InnerReader.GetInt32(i);
        }

        public int GetInt32(string name)
        {
            return this.InnerReader.GetInt32(this.GetOrdinal(name));
        }

        public long GetInt64(int i)
        {
            return this.InnerReader.GetInt64(i);
        }

        public long GetInt64(string name)
        {
            return this.InnerReader.GetInt64(this.GetOrdinal(name));
        }

        public string GetName(int i)
        {
            return this.InnerReader.GetName(i);
        }

        public string GetName(string name)
        {
            return this.InnerReader.GetName(this.GetOrdinal(name));
        }

        public int GetOrdinal(string name)
        {
            return this.InnerReader.GetOrdinal(name);
        }

        public DataTable GetSchemaTable()
        {
            return this.InnerReader.GetSchemaTable();
        }

        public string GetString(int i)
        {
            return this.InnerReader.GetString(i);
        }

        public string GetString(string name)
        {
            return this.InnerReader.GetString(this.GetOrdinal(name));
        }

        public object GetValue(int i)
        {
            return this.InnerReader.GetValue(i);
        }

        public object GetValue(string name)
        {
            return this.InnerReader.GetValue(this.GetOrdinal(name));
        }

        public int GetValues(object[] values)
        {
            return this.InnerReader.GetValues(values);
        }

        public bool IsDBNull(int i)
        {
            return this.InnerReader.IsDBNull(i);
        }

        public bool NextResult()
        {
            return this.InnerReader.NextResult();
        }

        public bool Read()
        {
            return this.InnerReader.Read();
        }

        public bool x797767007fb85012(string xc15bd84e01929885)
        {
            return this.InnerReader.IsDBNull(this.GetOrdinal(xc15bd84e01929885));
        }

        public int Depth
        {
            get
            {
                return this.InnerReader.Depth;
            }
        }

        public int FieldCount
        {
            get
            {
                return this.InnerReader.FieldCount;
            }
        }

        public System.Data.IDataReader InnerReader
        {
            [CompilerGenerated]
            get
            {
                return this.xc5674d4e912e69d6;
            }
            [CompilerGenerated]
            private set
            {
                this.xc5674d4e912e69d6 = value;
            }
        }

        public bool IsClosed
        {
            get
            {
                return this.InnerReader.IsClosed;
            }
        }

        public object this[string name]
        {
            get
            {
                return this.InnerReader[name];
            }
        }

        public object this[int i]
        {
            get
            {
                return this.GetValue(i);
            }
        }

        public int RecordsAffected
        {
            get
            {
                return this.InnerReader.RecordsAffected;
            }
        }

        [Dynamic]
        public object Value
        {
            [return: Dynamic]
            get
            {
                if (this._x4d0d7a709bc49dc1 == null)
                {
                    this._x4d0d7a709bc49dc1 = new x42ec19f833cd5adc(this.InnerReader);
                }
                return this._x4d0d7a709bc49dc1;
            }
        }
    }
}

