# SPQueryUtil - CamlBuilder
SPQUeryUtil now contains CamlBuilder which is designed to build CAML query without any CAML xml, but only code.

To build CAML query by CamlBuilder:

    using(SPSite site = new SPSite("http://mysiteurl"))
    {
      using(SPWeb web = site.OpenWeb())
      {
        SPList listToQuery = web.Lists["myList"];
        string query = CamlBuilder.BuildQuery(listToQuery, new And(new Eq("Status", "Completed"), new Eq("Id", "2")));
      }
    }

1, Support [operators and joins](https://msdn.microsoft.com/en-us/library/office/ms467521.aspx) (not all currently):

    CamlBuilder.BuildQuery(listToQuery, new Eq("status", "Completed"))
   
generates
   
    <Where>
      <Eq>
        <FieldRef Name="Status"></FieldRef>
        <Value Type="Text">Completed</Value>
      </Eq>
    </Where>
 
2, Combine operators by joins:

    CamlBulder.BuildQuery(listToQuery, new And(new Eq("status", "Completed"), new Eq("Id", "2"))

generates:

    <Where>
      <And>
        <Eq>
          <FieldRef Name="Status"></FieldRef>
          <Value Type="Text">Completed</Value>
        </Eq>
        <Eq>
          <FieldRef Name="ID"></FieldRef>
          <Value Type="Counter">2</Value>
        </Eq>
      </And>
    </Where>

If join contains more than two child elements, join element will be nested automatically:

    CamlBulder.BuildQuery(listToQuery, new And(new Eq("status", "Completed"), new Eq("title", "Task1"), new Eq("id", "1"))

generates:

    <Where>
      <And>
        <And>
          <Eq>
            <FieldRef Name="Status"></FieldRef>
            <Value Type="Text">Completed</Value>
          </Eq>
          <Eq>
            <FieldRef Name="Title"></FieldRef>
            <Value Type="Text">Task1</Value>
          </Eq>
        </And>
        <Eq>
          <FieldRef Name="ID"></FieldRef>
          <Value Type="Counter">2</Value>
        </Eq>
      </And>
    </Where>

3, You need to specify the field title and the value only, for examle: `new Eq("status", "Completed")`, the field title is "status", 
 which is not case sensitive, and the field name can be either Title or InternalName, CamlBuilder will handle everything to generate a valid CAML for this expression.
