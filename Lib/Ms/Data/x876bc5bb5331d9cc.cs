namespace Ms.Data
{
    using System;
    using System.Data;

    internal class x876bc5bb5331d9cc
    {
        private bool _xf997983e88b9b4af;
        private readonly xdcbbfbb72b3e3cda _xfd6dd6e53b1a26d5;

        public x876bc5bb5331d9cc(xdcbbfbb72b3e3cda command)
        {
            this._xfd6dd6e53b1a26d5 = command;
        }

        private void x079df65546b86bed(bool x6cfdbb424843d687)
        {
            bool flag = !this._xf997983e88b9b4af;
            goto Label_03CD;
        Label_0010:
            this._xfd6dd6e53b1a26d5.Data.Reader = new x6215066365db5120(this._xfd6dd6e53b1a26d5.Data.InnerCommand.ExecuteReader());
        Label_0040:
            this._xf997983e88b9b4af = true;
            if ((((uint) x6cfdbb424843d687) - ((uint) flag)) <= uint.MaxValue)
            {
                return;
            }
            goto Label_03CD;
        Label_0068:
            flag = !x6cfdbb424843d687;
            if (!flag)
            {
                goto Label_0010;
            }
            goto Label_0040;
        Label_0071:
            if (!flag)
            {
                goto Label_00F8;
            }
            if (4 == 0)
            {
                goto Label_035B;
            }
            goto Label_0068;
        Label_0083:
            if ((((uint) x6cfdbb424843d687) + ((uint) flag)) > uint.MaxValue)
            {
                goto Label_0071;
            }
            if (0 == 0)
            {
                goto Label_0068;
            }
            goto Label_0010;
        Label_00A4:
            flag = this._xfd6dd6e53b1a26d5.Data.Context.Data.OnExecuting == null;
            if ((((uint) x6cfdbb424843d687) + ((uint) flag)) < 0)
            {
                goto Label_02C4;
            }
            if ((((uint) flag) - ((uint) x6cfdbb424843d687)) >= 0)
            {
                goto Label_0071;
            }
        Label_00F8:
            this._xfd6dd6e53b1a26d5.Data.Context.Data.OnExecuting(new OnExecutingEventArgs(this._xfd6dd6e53b1a26d5.Data.InnerCommand));
            goto Label_0083;
        Label_029C:
            flag = !this._xfd6dd6e53b1a26d5.Data.Context.Data.UseTransaction;
            if (!flag)
            {
                flag = this._xfd6dd6e53b1a26d5.Data.Context.Data.Transaction != null;
            }
            else
            {
                do
                {
                    flag = this._xfd6dd6e53b1a26d5.Data.Context.Data.Transaction == null;
                    if (0 == 0)
                    {
                        if ((((uint) flag) + ((uint) x6cfdbb424843d687)) >= 0)
                        {
                            goto Label_041C;
                        }
                        goto Label_0305;
                    }
                }
                while (2 == 0);
            }
            if (!flag)
            {
                this._xfd6dd6e53b1a26d5.Data.Context.Data.Transaction = this._xfd6dd6e53b1a26d5.Data.Context.Data.Connection.BeginTransaction((System.Data.IsolationLevel) this._xfd6dd6e53b1a26d5.Data.Context.Data.IsolationLevel);
            }
            this._xfd6dd6e53b1a26d5.Data.InnerCommand.Transaction = this._xfd6dd6e53b1a26d5.Data.Context.Data.Transaction;
            goto Label_00A4;
        Label_02C4:
            this.x84a46dc89a9c670f();
            if (((uint) x6cfdbb424843d687) < 0)
            {
                goto Label_037E;
            }
            if (2 == 0)
            {
                goto Label_03BF;
            }
            goto Label_029C;
        Label_0305:
            flag = this._xfd6dd6e53b1a26d5.Data.InnerCommand.Connection.State == ConnectionState.Open;
            if ((((uint) flag) + ((uint) flag)) <= uint.MaxValue)
            {
                if (flag)
                {
                    goto Label_029C;
                }
                goto Label_02C4;
            }
            goto Label_041C;
        Label_035B:
            flag = this._xfd6dd6e53b1a26d5.Data.Context.Data.CommandTimeout == -2147483648;
        Label_037E:
            if (!flag)
            {
                this._xfd6dd6e53b1a26d5.Data.InnerCommand.CommandTimeout = this._xfd6dd6e53b1a26d5.Data.Context.Data.CommandTimeout;
            }
            goto Label_0305;
        Label_03BF:
            throw new Ms.Data.DataException("A query has already been executed on this command object. Please create a new command object.");
        Label_03CD:
            if (!flag)
            {
                flag = !this._xfd6dd6e53b1a26d5.Data.UseMultipleResultsets;
                if ((((uint) flag) >= 0) && flag)
                {
                    goto Label_03BF;
                }
                this._xfd6dd6e53b1a26d5.Data.Reader.NextResult();
                if (1 != 0)
                {
                    return;
                }
                if ((((uint) flag) - ((uint) x6cfdbb424843d687)) > uint.MaxValue)
                {
                    goto Label_02C4;
                }
            }
            goto Label_035B;
        Label_041C:
            if ((((uint) flag) + ((uint) flag)) <= uint.MaxValue)
            {
                while (true)
                {
                    if (flag)
                    {
                        if (((uint) flag) < 0)
                        {
                            break;
                        }
                        goto Label_00A4;
                    }
                    this._xfd6dd6e53b1a26d5.Data.Context.Data.Transaction = null;
                    if (-1 != 0)
                    {
                    }
                    this._xfd6dd6e53b1a26d5.Data.InnerCommand.Transaction = null;
                    if (((uint) flag) >= 0)
                    {
                        goto Label_00A4;
                    }
                }
            }
            goto Label_0083;
        }

        private void x7abc69015e07a7a0(Exception xc3c70767499bc99a)
        {
            bool flag = this._xfd6dd6e53b1a26d5.Data.Reader == null;
            if ((((uint) flag) & 0) == 0)
            {
                goto Label_00F1;
            }
            goto Label_004C;
        Label_003B:
            if (!flag)
            {
                goto Label_004F;
            }
            goto Label_013E;
        Label_004C:
            if (0 == 0)
            {
                goto Label_003B;
            }
        Label_004F:
            this._xfd6dd6e53b1a26d5.Data.Context.Data.OnError(new OnErrorEventArgs(this._xfd6dd6e53b1a26d5.Data.InnerCommand, xc3c70767499bc99a));
            if (8 == 0)
            {
                goto Label_0095;
            }
            if (0xff == 0)
            {
                goto Label_003B;
            }
            if (8 != 0)
            {
                goto Label_013E;
            }
            goto Label_00F1;
        Label_0092:
            if (!flag)
            {
                this._xfd6dd6e53b1a26d5.Data.Context.x20842211e363c9b2();
            }
        Label_0095:
            flag = this._xfd6dd6e53b1a26d5.Data.Context.Data.OnError == null;
            if (((uint) flag) < 0)
            {
                goto Label_0092;
            }
            if (((uint) flag) >= 0)
            {
                goto Label_004C;
            }
        Label_00F1:
            if (!flag)
            {
                this._xfd6dd6e53b1a26d5.Data.Reader.Close();
            }
            this._xfd6dd6e53b1a26d5.x18aa82658e198527();
            flag = !this._xfd6dd6e53b1a26d5.Data.Context.Data.UseTransaction;
            goto Label_0092;
        Label_013E:
            throw xc3c70767499bc99a;
        }

        private void x80fe6bc102dd42ed()
        {
            bool useMultipleResultsets = this._xfd6dd6e53b1a26d5.Data.UseMultipleResultsets;
            while (!useMultipleResultsets)
            {
                if (this._xfd6dd6e53b1a26d5.Data.Reader != null)
                {
                    this._xfd6dd6e53b1a26d5.Data.Reader.Close();
                }
                this._xfd6dd6e53b1a26d5.x18aa82658e198527();
                if (0 == 0)
                {
                    return;
                }
            }
        }

        private void x84a46dc89a9c670f()
        {
            bool flag = this._xfd6dd6e53b1a26d5.Data.Context.Data.OnConnectionOpening == null;
            do
            {
                if (!flag)
                {
                    this._xfd6dd6e53b1a26d5.Data.Context.Data.OnConnectionOpening(new OnConnectionOpeningEventArgs(this._xfd6dd6e53b1a26d5.Data.InnerCommand.Connection));
                }
                else if (0x7fffffff != 0)
                {
                    break;
                }
            }
            while (-2147483648 == 0);
            this._xfd6dd6e53b1a26d5.Data.InnerCommand.Connection.Open();
            flag = this._xfd6dd6e53b1a26d5.Data.Context.Data.OnConnectionOpened == null;
        Label_002A:
            if (!flag)
            {
                this._xfd6dd6e53b1a26d5.Data.Context.Data.OnConnectionOpened(new OnConnectionOpenedEventArgs(this._xfd6dd6e53b1a26d5.Data.InnerCommand.Connection));
                if (0 == 0)
                {
                    if (-2 == 0)
                    {
                        goto Label_002A;
                    }
                    if (8 != 0)
                    {
                    }
                }
            }
        }

        internal void xa266202b32508032(bool x6cfdbb424843d687, Action xab8fe3cd8c5556fb)
        {
            try
            {
                bool flag;
                this.x079df65546b86bed(x6cfdbb424843d687);
                goto Label_0091;
            Label_0010:
                this._xfd6dd6e53b1a26d5.Data.Context.Data.OnExecuted(new OnExecutedEventArgs(this._xfd6dd6e53b1a26d5.Data.InnerCommand));
                return;
            Label_0047:
                if (!flag)
                {
                    goto Label_0010;
                }
                goto Label_007F;
            Label_004C:
                flag = this._xfd6dd6e53b1a26d5.Data.Context.Data.OnExecuted == null;
                if ((((uint) flag) & 0) == 0)
                {
                    goto Label_0047;
                }
            Label_007F:
                if (((uint) flag) >= 0)
                {
                    return;
                }
            Label_0091:
                xab8fe3cd8c5556fb();
                goto Label_004C;
            }
            catch (Exception exception)
            {
                this.x7abc69015e07a7a0(exception);
            }
            finally
            {
                this.x80fe6bc102dd42ed();
            }
        }
    }
}

