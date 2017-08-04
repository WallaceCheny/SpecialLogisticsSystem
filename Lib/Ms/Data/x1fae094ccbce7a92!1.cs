namespace Ms.Data
{
    using System;

    internal class x1fae094ccbce7a92<TEntity>
    {
        internal TList x775c5827e65df2da<TList>(DbCommandData x4a3f0a05c02f235f, Action<TEntity, IDataReader> xb4c68d3daf262308) where TList: IList<TEntity>
        {
            x252697994e97c9c4<TEntity> xecc;
            TEntity local2;
            TEntity local3;
            TList local4;
            bool flag;
            TList local = (TList) x4a3f0a05c02f235f.Context.Data.EntityFactory.Create(typeof(TList));
            goto Label_01DC;
        Label_0030:
            flag = x4a3f0a05c02f235f.Reader.Read();
            if (flag)
            {
                goto Label_009B;
            }
        Label_0042:
            local4 = local;
            if ((((uint) flag) <= uint.MaxValue) || (-2147483648 != 0))
            {
                return local4;
            }
            goto Label_01DC;
        Label_0096:
            if (0 == 0)
            {
                goto Label_0030;
            }
        Label_009B:
            flag = !(x4a3f0a05c02f235f.Reader.GetFieldType(0) == typeof(TEntity));
            if (flag)
            {
                local3 = (TEntity) Convert.ChangeType(x4a3f0a05c02f235f.Reader.GetValue(0), typeof(TEntity));
                if ((((uint) flag) + ((uint) flag)) < 0)
                {
                    goto Label_011C;
                }
            }
            else
            {
                local3 = (TEntity) x4a3f0a05c02f235f.Reader.GetValue(0);
            }
            local.Add(local3);
            goto Label_0096;
        Label_011C:
            xb4c68d3daf262308(local2, x4a3f0a05c02f235f.Reader);
        Label_012A:
            local.Add(local2);
        Label_013A:
            flag = x4a3f0a05c02f235f.Reader.Read();
            if (-1 != 0)
            {
                if (flag)
                {
                    local2 = (TEntity) x4a3f0a05c02f235f.Context.Data.EntityFactory.Create(typeof(TEntity));
                    flag = xb4c68d3daf262308 != null;
                    if (flag)
                    {
                        goto Label_011C;
                    }
                    xecc.x398c2378fe09de36(local2);
                    if (4 != 0)
                    {
                        if ((((uint) flag) + ((uint) flag)) < 0)
                        {
                            goto Label_0096;
                        }
                        goto Label_012A;
                    }
                    goto Label_01C6;
                }
                goto Label_0042;
            }
            goto Label_0030;
        Label_01C6:
            xecc = new x252697994e97c9c4<TEntity>(x4a3f0a05c02f235f, typeof(TEntity));
            goto Label_013A;
        Label_01DC:
            flag = !x7927126fe5cc7aa8.x218bb7401cb15bc9<TEntity>();
            if (!flag)
            {
                goto Label_01C6;
            }
            goto Label_0030;
        }

        internal TEntity xadaedfe74982380c(DbCommandData x4a3f0a05c02f235f, Action<TEntity, IDataReader> xcaf17cffef745664)
        {
            TEntity local2;
            TEntity local = default(TEntity);
        Label_018C:
            if (!x7927126fe5cc7aa8.x218bb7401cb15bc9<TEntity>())
            {
                goto Label_0099;
            }
            x252697994e97c9c4<TEntity> xecc = null;
            xecc = new x252697994e97c9c4<TEntity>(x4a3f0a05c02f235f, typeof(TEntity));
            if (0 != 0)
            {
                return local;
            }
            bool flag = !x4a3f0a05c02f235f.Reader.Read();
            if (!flag)
            {
                local = (TEntity) x4a3f0a05c02f235f.Context.Data.EntityFactory.Create(typeof(TEntity));
                if (((uint) flag) <= uint.MaxValue)
                {
                    if ((((uint) flag) + ((uint) flag)) >= 0)
                    {
                    Label_0108:
                        flag = xcaf17cffef745664 != null;
                        if (((uint) flag) <= uint.MaxValue)
                        {
                            if (!flag)
                            {
                                xecc.x398c2378fe09de36(local);
                                return local;
                            }
                            if (0 == 0)
                            {
                                goto Label_00CE;
                            }
                            goto Label_0108;
                        }
                    }
                    else
                    {
                        goto Label_00CE;
                    }
                }
                goto Label_018C;
            }
            if ((((uint) flag) & 0) != 0)
            {
                goto Label_0099;
            }
            if (0 == 0)
            {
                return local;
            }
            return local2;
        Label_002F:
            if (flag)
            {
                return local;
            }
        Label_0034:
            flag = !(x4a3f0a05c02f235f.Reader.GetFieldType(0) == typeof(TEntity));
            if (!flag)
            {
                local = (TEntity) x4a3f0a05c02f235f.Reader.GetValue(0);
            }
            else
            {
                local = (TEntity) Convert.ChangeType(x4a3f0a05c02f235f.Reader.GetValue(0), typeof(TEntity));
            }
            if ((((uint) flag) - ((uint) flag)) >= 0)
            {
                return local;
            }
            goto Label_002F;
        Label_0099:
            flag = !x4a3f0a05c02f235f.Reader.Read();
            if ((((uint) flag) - ((uint) flag)) >= 0)
            {
                goto Label_002F;
            }
            goto Label_0034;
        Label_00CE:
            xcaf17cffef745664(local, x4a3f0a05c02f235f.Reader);
            return local;
        }
    }
}

