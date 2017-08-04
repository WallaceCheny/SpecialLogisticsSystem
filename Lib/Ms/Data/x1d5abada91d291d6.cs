namespace Ms.Data
{
    using Microsoft.CSharp.RuntimeBinder;
    using System;
    using System.Collections.Generic;
    using System.Dynamic;
    using System.Runtime.CompilerServices;

    internal class x1d5abada91d291d6
    {
        [return: Dynamic(new bool[] { false, true })]
        public List<object> x8d7d879bea89ae19(DbCommandData x4a3f0a05c02f235f)
        {
            xe9a2666102b20a2e xeabae;
            bool flag;
            List<object> list = new List<object>();
            if (((uint) flag) <= uint.MaxValue)
            {
                xeabae = new xe9a2666102b20a2e(x4a3f0a05c02f235f);
            }
            while (true)
            {
                if (!x4a3f0a05c02f235f.Reader.Read())
                {
                    List<object> list2 = list;
                    if (-2147483648 != 0)
                    {
                        return list2;
                    }
                }
                object obj2 = xeabae.x398c2378fe09de36();
                list.Add((dynamic) obj2);
            }
        }

        [return: Dynamic]
        public object xadaedfe74982380c(DbCommandData x4a3f0a05c02f235f)
        {
            object obj3;
            bool flag;
            xe9a2666102b20a2e xeabae = new xe9a2666102b20a2e(x4a3f0a05c02f235f);
            object obj2 = null;
            if ((((uint) flag) - ((uint) flag)) >= 0)
            {
                if ((((uint) flag) & 0) != 0)
                {
                    return obj3;
                }
                if (x4a3f0a05c02f235f.Reader.Read())
                {
                    obj2 = xeabae.x398c2378fe09de36();
                }
                return obj2;
            }
            return obj3;
        }

        [return: Dynamic]
        public object xc8029fa677c82cd1(DbCommandData x4a3f0a05c02f235f)
        {
            object obj3;
            bool flag;
            object obj2 = new ExpandoObject();
            xe9a2666102b20a2e xeabae = new xe9a2666102b20a2e(x4a3f0a05c02f235f);
            List<object> list = new List<object>();
            List<string> list2 = xeabae.xc567147cf8b4fd5d();
            goto Label_0108;
        Label_0013:
            <ExecuteListAndFeild>o__SiteContainer2.<>p__Site5.Target(<ExecuteListAndFeild>o__SiteContainer2.<>p__Site5, obj2, list2);
            return obj2;
        Label_009B:;
            <ExecuteListAndFeild>o__SiteContainer2.<>p__Site4 = CallSite<Func<CallSite, object, List<object>, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "items", typeof(x1d5abada91d291d6), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null), CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null) }));
            if (4 == 0)
            {
                goto Label_0108;
            }
        Label_00EA:
            <ExecuteListAndFeild>o__SiteContainer2.<>p__Site4.Target(<ExecuteListAndFeild>o__SiteContainer2.<>p__Site4, obj2, list);
            if (3 == 0)
            {
                goto Label_0136;
            }
            if ((((uint) flag) + ((uint) flag)) < 0)
            {
                goto Label_0013;
            }
            goto Label_0126;
        Label_0108:
            if (x4a3f0a05c02f235f.Reader.Read())
            {
                goto Label_012D;
            }
            if (8 != 0)
            {
                if (<ExecuteListAndFeild>o__SiteContainer2.<>p__Site4 == null)
                {
                    goto Label_009B;
                }
                goto Label_00EA;
            }
            if (0 == 0)
            {
                goto Label_009B;
            }
        Label_0126:
            if (1 != 0)
            {
                if (0 != 0)
                {
                    object obj4;
                    return obj4;
                }
                goto Label_0013;
            }
        Label_012D:
            obj3 = xeabae.x398c2378fe09de36();
        Label_0136:
            if (<ExecuteListAndFeild>o__SiteContainer2.<>p__Site3 == null)
            {
                <ExecuteListAndFeild>o__SiteContainer2.<>p__Site3 = CallSite<Action<CallSite, List<object>, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "Add", null, typeof(x1d5abada91d291d6), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null), CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
            }
            <ExecuteListAndFeild>o__SiteContainer2.<>p__Site3.Target(<ExecuteListAndFeild>o__SiteContainer2.<>p__Site3, list, obj3);
            goto Label_0108;
        }
    }
}

