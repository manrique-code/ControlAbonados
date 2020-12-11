diff --git a/Visual proyect/ControlAbonados/.vs/ControlAbonados/v16/.suo b/Visual proyect/ControlAbonados/.vs/ControlAbonados/v16/.suo
index 0a509dd..520a65d 100644
Binary files a/Visual proyect/ControlAbonados/.vs/ControlAbonados/v16/.suo and b/Visual proyect/ControlAbonados/.vs/ControlAbonados/v16/.suo differ
diff --git a/Visual proyect/ControlAbonados/ControlAbonados/ControlAbonados.csproj b/Visual proyect/ControlAbonados/ControlAbonados/ControlAbonados.csproj
index 6f71e71..4c94689 100644
--- a/Visual proyect/ControlAbonados/ControlAbonados/ControlAbonados.csproj	
+++ b/Visual proyect/ControlAbonados/ControlAbonados/ControlAbonados.csproj	
@@ -176,6 +176,14 @@
     <Compile Include="Migrations\202012091008342_CodPegueFechaEstadoPegueMigration.Designer.cs">
       <DependentUpon>202012091008342_CodPegueFechaEstadoPegueMigration.cs</DependentUpon>
     </Compile>
+    <Compile Include="Migrations\202012100859213_NumeroIdentidadNoEsUniqueMigration.cs" />
+    <Compile Include="Migrations\202012100859213_NumeroIdentidadNoEsUniqueMigration.Designer.cs">
+      <DependentUpon>202012100859213_NumeroIdentidadNoEsUniqueMigration.cs</DependentUpon>
+    </Compile>
+    <Compile Include="Migrations\202012112028101_NotasPegueMigration.cs" />
+    <Compile Include="Migrations\202012112028101_NotasPegueMigration.Designer.cs">
+      <DependentUpon>202012112028101_NotasPegueMigration.cs</DependentUpon>
+    </Compile>
     <Compile Include="Migrations\Configuration.cs" />
     <Compile Include="Models\Abonado.cs" />
     <Compile Include="Models\Bloque.cs" />
@@ -188,6 +196,18 @@
     <Compile Include="Models\TipoPegue.cs" />
     <Compile Include="Program.cs" />
     <Compile Include="Properties\AssemblyInfo.cs" />
+    <Compile Include="Reportes\frmListadoTodoAbonados.cs">
+      <SubType>Form</SubType>
+    </Compile>
+    <Compile Include="Reportes\frmListadoTodoAbonados.Designer.cs">
+      <DependentUpon>frmListadoTodoAbonados.cs</DependentUpon>
+    </Compile>
+    <Compile Include="Reportes\ListadoTodoAbonados.cs">
+      <AutoGen>True</AutoGen>
+      <DesignTime>True</DesignTime>
+      <DependentUpon>ListadoTodoAbonados.rpt</DependentUpon>
+      <SubType>Component</SubType>
+    </Compile>
     <EmbeddedResource Include="Forms\Abonados.resx">
       <DependentUpon>Abonados.cs</DependentUpon>
     </EmbeddedResource>
@@ -263,6 +283,12 @@
     <EmbeddedResource Include="Migrations\202012091008342_CodPegueFechaEstadoPegueMigration.resx">
       <DependentUpon>202012091008342_CodPegueFechaEstadoPegueMigration.cs</DependentUpon>
     </EmbeddedResource>
+    <EmbeddedResource Include="Migrations\202012100859213_NumeroIdentidadNoEsUniqueMigration.resx">
+      <DependentUpon>202012100859213_NumeroIdentidadNoEsUniqueMigration.cs</DependentUpon>
+    </EmbeddedResource>
+    <EmbeddedResource Include="Migrations\202012112028101_NotasPegueMigration.resx">
+      <DependentUpon>202012112028101_NotasPegueMigration.cs</DependentUpon>
+    </EmbeddedResource>
     <EmbeddedResource Include="Properties\Resources.resx">
       <Generator>ResXFileCodeGenerator</Generator>
       <LastGenOutput>Resources.Designer.cs</LastGenOutput>
@@ -273,6 +299,13 @@
       <DependentUpon>Resources.resx</DependentUpon>
       <DesignTime>True</DesignTime>
     </Compile>
+    <EmbeddedResource Include="Reportes\frmListadoTodoAbonados.resx">
+      <DependentUpon>frmListadoTodoAbonados.cs</DependentUpon>
+    </EmbeddedResource>
+    <EmbeddedResource Include="Reportes\ListadoTodoAbonados.rpt">
+      <Generator>CrystalDecisions.VSDesigner.CodeGen.ReportCodeGenerator</Generator>
+      <LastGenOutput>ListadoTodoAbonados.cs</LastGenOutput>
+    </EmbeddedResource>
     <None Include="packages.config" />
     <None Include="Properties\Settings.settings">
       <Generator>SettingsSingleFileGenerator</Generator>
@@ -332,5 +365,9 @@
   <ItemGroup>
     <None Include="res\icons\home-negro-512.png" />
   </ItemGroup>
+  <ItemGroup>
+    <Service Include="{C0C07587-41A7-46C8-8FBD-3F9C8EBE2DDC}" />
+  </ItemGroup>
+  <ItemGroup />
   <Import Project="$(MSBuildToolsPath)\Microsoft.CSharp.targets" />
 </Project>
\ No newline at end of file
diff --git a/Visual proyect/ControlAbonados/ControlAbonados/ControlAbonados.csproj.user b/Visual proyect/ControlAbonados/ControlAbonados/ControlAbonados.csproj.user
index c10e84b..f175dca 100644
--- a/Visual proyect/ControlAbonados/ControlAbonados/ControlAbonados.csproj.user	
+++ b/Visual proyect/ControlAbonados/ControlAbonados/ControlAbonados.csproj.user	
@@ -3,4 +3,7 @@
   <PropertyGroup>
     <ProjectView>ProjectFiles</ProjectView>
   </PropertyGroup>
+  <PropertyGroup>
+    <ReferencePath>C:\Program Files (x86)\SAP BusinessObjects\Crystal Reports for .NET Framework 4.0\Common\SAP BusinessObjects Enterprise XI 4.0\win32_x86\dotnet\</ReferencePath>
+  </PropertyGroup>
 </Project>
\ No newline at end of file
diff --git a/Visual proyect/ControlAbonados/ControlAbonados/Data/DataAbonadoAccess.cs b/Visual proyect/ControlAbonados/ControlAbonados/Data/DataAbonadoAccess.cs
index fe966a9..c6a746a 100644
--- a/Visual proyect/ControlAbonados/ControlAbonados/Data/DataAbonadoAccess.cs	
+++ b/Visual proyect/ControlAbonados/ControlAbonados/Data/DataAbonadoAccess.cs	
@@ -1,5 +1,7 @@
 ﻿using System;
 using System.Collections.Generic;
+using System.Data;
+using System.Data.SqlClient;
 using System.Linq;
 using System.Text;
 using System.Threading.Tasks;
@@ -11,6 +13,207 @@ namespace ControlAbonados.Data
     public class DataAbonadoAccess
     {
         static DataContext ctx = new DataContext();
+        static string cnnStr = Properties.Settings.Default.cnnString.ToString();
+
+        public static void actualizarFEP(
+                int idFEP,
+                int idEstadoPegue,
+                int idMes,
+                string year
+            )
+        {
+            FechaEstadoPegue fep = (
+                    from feps in ctx.FechaEstadoPegues
+                    where feps.IdFechaEstadoPegue == idFEP
+                    select feps
+                ).SingleOrDefault();
+
+            fep.IdEstadoPegue = idEstadoPegue;
+            fep.IdMes = idMes;
+            fep.Año = year;
+
+            ctx.SaveChanges();
+        }
+        /*
+         * eliminamos un fechaEstadoPegue debido a que el estado cambio
+         */
+        public static void eliminarFechaEstadoPegue(string codPegue)
+        {
+            FechaEstadoPegue fep = (
+                    from feps in ctx.FechaEstadoPegues
+                    where feps.CodPegue == codPegue
+                    select feps             
+                ).SingleOrDefault();
+            ctx.FechaEstadoPegues.Remove(fep);
+            ctx.SaveChanges();
+        }
+
+        /*
+         * obtenemos el ultimo mes pagado en un control del pago 
+         */
+        public static int obtenerUltimoMesPagado(string codPegue)
+        {
+            var ultimoMes = (
+                    from pago in ctx.ControlPago
+                    where pago.CodPegue == codPegue
+                    select new
+                    {
+                        pago.IdMes
+                    }
+                ).LastOrDefault();
+
+            return ultimoMes.IdMes;
+        }
+
+
+        /*
+         * 
+         */
+        public static string[] obtenerMesDeFechaControlPegue(string codPegue)
+        {
+            var m = (
+                    from pegues in ctx.Pegue
+                    join fep in ctx.FechaEstadoPegues
+                    on pegues.CodPegue equals fep.CodPegue
+                    join mes in ctx.Mes
+                    on fep.IdMes equals mes.IdMes
+                    where pegues.CodPegue == codPegue
+                    select new
+                    {
+                        mes.IdMes,
+                        mes.NombreMes,
+                        fep.Año,
+                        fep.IdEstadoPegue,
+                        fep.IdFechaEstadoPegue
+                    }
+                ).SingleOrDefault();
+
+            return new string[5] { m.IdMes.ToString(), m.NombreMes, m.Año, m.IdEstadoPegue.ToString(), m.IdFechaEstadoPegue.ToString() };
+        }
+
+        /*
+         * obtener el id del estado del pegue a traves del nombre del estado del pegue
+         */
+        public static int obtenerEstadoPegueIDPorNombre(string estadoPegue)
+        {
+            var ep = ctx.EstadoPegue.SingleOrDefault(x => x.NombreEstadoPegue == estadoPegue);
+            return ep.IdEstadoPegue;
+        }
+
+        /*
+         * obtener el id del tipo pegue a través del nombre del tipo de pegue
+         */
+        public static int obtenerTipoPegueIDPorNombre(string tipoPegue)
+        {
+            var tp = ctx.TipoPegue.SingleOrDefault(x => x.NombreTipoPegue == tipoPegue);
+            return tp.IdTipoPegue; 
+        }
+
+        /*
+         * funcion para saber si un abonado ha pagado algun mes
+         */
+        public static bool tieneMesesPagados(string codPegue)
+        {
+            var pago = ctx.ControlPago.Count(x => x.CodPegue == codPegue);
+            return (pago > 0);
+        }
+
+        /*
+         * funcion para saber si un pegue tiene fechaestadopegue
+         */
+        public static bool existeFechaEstadoPegue(string codPegue)
+        {
+            var pegue = ctx.FechaEstadoPegues.Count(x => x.CodPegue == codPegue);
+            return (pegue > 0);
+        }
+
+        /*
+         * funcion para obtener el numero de identidad segun el id del abonaod
+         */
+        public static string obtenerNumIdentidadByID(int idAbonado)
+        {
+            var numId = (
+                    from abonado in ctx.Abonado
+                    where abonado.IdAbonado == idAbonado
+                    select new
+                    {
+                        abonado.NumIdentidad
+                    }
+                ).SingleOrDefault();
+            string numeroIdentidad = numId.NumIdentidad.ToString();
+            return numeroIdentidad;
+        }
+
+
+        /*
+         * funcion para obtener el codigo de pegue segun el bloque y casa
+         */
+        public static string obtenerCodigoPegueByPegue(
+                string numBloque,
+                string numCasa
+            )
+        {
+            var codigoPegue = (
+                    from pegue in ctx.Pegue
+                    where pegue.Bloque.NumeroBloque == numBloque && pegue.NumCasa == numCasa
+                    select new
+                    {
+                        pegue.CodPegue
+                    }
+                ).SingleOrDefault();
+            return codigoPegue.CodPegue;
+        }
+
+        /*
+         * funcion para actualizar el abonado
+         */
+        public static void actualizarAbonado(
+                int IdAbonado,
+                string nombres,
+                string apellidos,
+                string numeroIdentidad = ""
+            )
+        {
+            Abonado abonado = (
+                    from a in ctx.Abonado
+                    where a.IdAbonado == IdAbonado
+                    select a
+                ).SingleOrDefault();
+
+            abonado.Nombres = nombres;
+            abonado.Apellidos = apellidos;
+            abonado.NumIdentidad = numeroIdentidad;
+
+            ctx.SaveChanges();
+        }
+
+
+        /*
+         * funcion que actualiza el pegue
+         */
+        public static void actualizarPegue(
+                string codigoPegue,
+                string numCasa,
+                int TipoPegue,
+                int TipoEstaodPegueID,
+                int IdBloque,
+                string nota
+            )
+        {
+            Pegue pegue = (
+                    from p in ctx.Pegue
+                    where p.CodPegue == codigoPegue
+                    select p
+                ).SingleOrDefault();
+
+            pegue.NumCasa = numCasa;
+            pegue.IdTipoPegue = TipoPegue;
+            pegue.IdEstadoPegue = TipoEstaodPegueID;
+            pegue.IdBloque = IdBloque;
+            pegue.Nota = nota;
+
+            ctx.SaveChanges();
+        }
 
         /*
          * Funcion para imprimir toda la informacion de los abonados
@@ -21,61 +224,197 @@ namespace ControlAbonados.Data
             {
                 case "":
                     // mandar todo lo de la consulta
-                    var datos = (
+                    using(SqlConnection cnn = new SqlConnection(cnnStr))
+                    {
+                        using(SqlDataAdapter da = new SqlDataAdapter())
+                        {
+                            da.SelectCommand = new SqlCommand(@"select a.IdAbonado '#',
+                                    upper(a.Nombres) Nombre,
+                                    upper(a.Apellidos) Apellido,
+                                    tp.NombreTipoPegue Pegue,
+                                    b.NumeroBloque B,
+                                    p.NumCasa C,
+                                    ep.NombreEstadoPegue Estado,
+	                                count(m.NombreMes) 'Meses Pagados',
+                                    p.Nota
+	                                from pegues p inner join ControlPagoes cp
+	                                on p.CodPegue = cp.CodPegue
+	                                inner join mes m
+	                                on cp.IdMes = m.IdMes
+	                                inner join Abonadoes a
+	                                on p.IdAbonado = a.IdAbonado
+	                                inner join Bloques b
+	                                on p.IdBloque = b.IdBloque
+	                                inner join TipoPegues tp
+	                                on p.IdTipoPegue = tp.IdTipoPegue
+	                                full join FechaEstadoPegues fep
+	                                on p.CodPegue = fep.CodPegue
+	                                inner join EstadoPegues ep
+	                                on p.IdEstadoPegue = ep.IdEstadoPegue
+                                group by upper(a.Nombres),
+                                upper(a.Apellidos),
+                                tp.NombreTipoPegue,
+                                b.NumeroBloque,
+                                p.NumCasa,
+                                ep.NombreEstadoPegue,
+                                a.IdAbonado,
+                                p.Nota
+                                union
+                                select a.IdAbonado '#',
+                                    upper(a.Nombres) Nombre,
+                                    upper(a.Apellidos) Apellido,
+                                    tp.NombreTipoPegue Pegue,
+                                    b.NumeroBloque B,
+                                    p.NumCasa C,
+                                    ep.NombreEstadoPegue Estado,
+	                                count(cp.IdMes) 'Meses Pagados',
+                                    p.Nota
+	                                from pegues p full join ControlPagoes cp
+	                                on p.CodPegue = cp.CodPegue
+	                                inner join Abonadoes a
+	                                on p.IdAbonado = a.IdAbonado
+	                                inner join Bloques b
+	                                on p.IdBloque = b.IdBloque
+	                                inner join TipoPegues tp
+	                                on p.IdTipoPegue = tp.IdTipoPegue
+	                                inner join EstadoPegues ep
+	                                on p.IdEstadoPegue = ep.IdEstadoPegue
+                                group by upper(a.Nombres),
+                                    upper(a.Apellidos),
+                                    tp.NombreTipoPegue,
+                                    b.NumeroBloque,
+                                    p.NumCasa,
+                                    ep.NombreEstadoPegue,
+                                    a.IdAbonado,
+                                    p.Nota", cnn);
+
+                            using (DataTable dt = new DataTable())
+                            {
+                                da.Fill(dt);
+                                dgv.DataSource = dt;
+                            }
+
+                        }
+                    }
+                    /*var datos = (
                             from pegue in ctx.Pegue
+                            orderby pegue.Abonado.IdAbonado
                             join controlPago in ctx.ControlPago
                             on pegue.CodPegue equals controlPago.CodPegue
                             group pegue by new
                             {
-                                pegue.Abonado.NumIdentidad,
+                                pegue.Abonado.IdAbonado,
                                 pegue.Abonado.Nombres,
                                 pegue.Abonado.Apellidos,
                                 pegue.Bloque.NumeroBloque,
                                 pegue.NumCasa,
                                 pegue.CodPegue,
-                                pegue.TipoPegue.NombreTipoPegue
+                                pegue.TipoPegue.NombreTipoPegue,
+                                pegue.EstadoPegue.NombreEstadoPegue
                             } into pegues
                             select new
                             {
-                                Identidad = pegues.Key.NumIdentidad,
+                                N = pegues.Key.IdAbonado,
                                 Nombre = pegues.Key.Nombres.ToUpper() + " " + pegues.Key.Apellidos.ToUpper(),
                                 Bloque = pegues.Key.NumeroBloque,
                                 Casa = pegues.Key.NumCasa,
                                 Pegue = pegues.Key.NombreTipoPegue,
-                                MesesPagados = pegues.Count()
-                            }
+                                Estado = pegues.Key.NombreEstadoPegue
+                            } 
                         ).ToList();
 
-                    dgv.DataSource = datos;
+                    dgv.DataSource = datos;*/
 
                     break;
                 case "Nombre":
-                    var nombre = (
-                            from pegue in ctx.Pegue
-                            join controlPago in ctx.ControlPago
-                            on pegue.CodPegue equals controlPago.CodPegue
-                            where pegue.Abonado.Nombres.StartsWith(buscar)
-                            group pegue by new
-                            {
-                                pegue.Abonado.NumIdentidad,
-                                pegue.Abonado.Nombres,
-                                pegue.Abonado.Apellidos,
-                                pegue.Bloque.NumeroBloque,
-                                pegue.NumCasa,
-                                pegue.CodPegue,
-                                pegue.TipoPegue.NombreTipoPegue
-                            } into pegues
-                            select new
+
+                    using (SqlConnection cnn = new SqlConnection(cnnStr))
+                    {
+                        using (SqlDataAdapter da = new SqlDataAdapter())
+                        {
+                            da.SelectCommand = new SqlCommand(@"
+                                select pegue.N,
+                                pegue.Nombre,
+                                pegue.Apellido,
+                                pegue.NumeroBloque Bloque,
+                                pegue.NumCasa Casa,
+                                pegue.Estado,
+                                pegue.[Meses Pagados],
+                                pegue.Nota
+                                from
+                                (select a.IdAbonado N,
+	                                upper(a.Nombres) Nombre,
+                                    upper(a.Apellidos) Apellido,
+                                    tp.NombreTipoPegue Pegue,
+                                    b.NumeroBloque,
+                                    p.NumCasa,
+                                    ep.NombreEstadoPegue Estado,
+	                                count(m.NombreMes) 'Meses Pagados',
+                                    p.Nota
+	                                from pegues p inner join ControlPagoes cp
+	                                on p.CodPegue = cp.CodPegue
+	                                inner join mes m
+	                                on cp.IdMes = m.IdMes
+	                                inner join Abonadoes a
+	                                on p.IdAbonado = a.IdAbonado
+	                                inner join Bloques b
+	                                on p.IdBloque = b.IdBloque
+	                                inner join TipoPegues tp
+	                                on p.IdTipoPegue = tp.IdTipoPegue
+	                                full join FechaEstadoPegues fep
+	                                on p.CodPegue = fep.CodPegue
+	                                inner join EstadoPegues ep
+	                                on p.IdEstadoPegue = ep.IdEstadoPegue
+                                group by 
+                                a.IdAbonado,
+                                upper(a.Nombres),
+                                upper(a.Apellidos),
+                                tp.NombreTipoPegue,
+                                b.NumeroBloque,
+                                p.NumCasa,
+                                ep.NombreEstadoPegue,
+                                p.Nota
+                                union
+                                select a.IdAbonado N,
+	                                upper(a.Nombres) Nombre,
+                                    upper(a.Apellidos) Apellido,
+                                    tp.NombreTipoPegue Pegue,
+                                    b.NumeroBloque,
+                                    p.NumCasa,
+                                    ep.NombreEstadoPegue Estado,
+	                                count(cp.IdMes) 'Meses Pagados',
+                                    p.Nota
+	                                from pegues p full join ControlPagoes cp
+	                                on p.CodPegue = cp.CodPegue
+	                                inner join Abonadoes a
+	                                on p.IdAbonado = a.IdAbonado
+	                                inner join Bloques b
+	                                on p.IdBloque = b.IdBloque
+	                                inner join TipoPegues tp
+	                                on p.IdTipoPegue = tp.IdTipoPegue
+	                                inner join EstadoPegues ep
+	                                on p.IdEstadoPegue = ep.IdEstadoPegue
+                                group by
+                                a.IdAbonado, 
+	                                upper(a.Nombres),
+                                    upper(a.Apellidos),
+                                    tp.NombreTipoPegue,
+                                    b.NumeroBloque,
+                                    p.NumCasa,
+                                    ep.NombreEstadoPegue,
+                                    p.Nota) pegue
+                                where pegue.Nombre like @nombre + '%'", cnn);
+                            da.SelectCommand.Parameters.Add("@nombre", SqlDbType.NVarChar).Value = buscar;
+
+                            using (DataTable dt = new DataTable())
                             {
-                                Identidad = pegues.Key.NumIdentidad,
-                                Nombre = pegues.Key.Nombres.ToUpper() + " " + pegues.Key.Apellidos.ToUpper(),
-                                Bloque = pegues.Key.NumeroBloque,
-                                Casa = pegues.Key.NumCasa,
-                                Pegue = pegues.Key.NombreTipoPegue,
-                                MesesPagados = pegues.Count()
+                                da.Fill(dt);
+                                dgv.DataSource = dt;
                             }
-                        ).ToList();
-                    dgv.DataSource = nombre;
+
+                        }
+                    }
+
                     break;
                 case "Bloque":
                     var bloque = (
@@ -85,6 +424,7 @@ namespace ControlAbonados.Data
                             where pegue.Bloque.NumeroBloque.StartsWith(buscar)
                             group pegue by new
                             {
+                                pegue.Abonado.IdAbonado,
                                 pegue.Abonado.NumIdentidad,
                                 pegue.Abonado.Nombres,
                                 pegue.Abonado.Apellidos,
@@ -95,6 +435,7 @@ namespace ControlAbonados.Data
                             } into pegues
                             select new
                             {
+                                N = pegues.Key.IdAbonado,
                                 Identidad = pegues.Key.NumIdentidad,
                                 Nombre = pegues.Key.Nombres.ToUpper() + " " + pegues.Key.Apellidos.ToUpper(),
                                 Bloque = pegues.Key.NumeroBloque,
@@ -113,6 +454,7 @@ namespace ControlAbonados.Data
                             where pegue.NumCasa.StartsWith(buscar)
                             group pegue by new
                             {
+                                pegue.Abonado.IdAbonado,
                                 pegue.Abonado.NumIdentidad,
                                 pegue.Abonado.Nombres,
                                 pegue.Abonado.Apellidos,
@@ -123,6 +465,7 @@ namespace ControlAbonados.Data
                             } into pegues
                             select new
                             {
+                                N = pegues.Key.IdAbonado,
                                 Identidad = pegues.Key.NumIdentidad,
                                 Nombre = pegues.Key.Nombres.ToUpper() + " " + pegues.Key.Apellidos.ToUpper(),
                                 Bloque = pegues.Key.NumeroBloque,
@@ -141,6 +484,7 @@ namespace ControlAbonados.Data
                             where controlPago.Mes.NombreMes.StartsWith(buscar)
                             group pegue by new
                             {
+                                pegue.Abonado.IdAbonado,
                                 pegue.Abonado.NumIdentidad,
                                 pegue.Abonado.Nombres,
                                 pegue.Abonado.Apellidos,
@@ -151,6 +495,7 @@ namespace ControlAbonados.Data
                             } into pegues
                             select new
                             {
+                                N = pegues.Key.IdAbonado,
                                 Identidad = pegues.Key.NumIdentidad,
                                 Nombre = pegues.Key.Nombres.ToUpper() + " " + pegues.Key.Apellidos.ToUpper(),
                                 Bloque = pegues.Key.NumeroBloque,
@@ -169,6 +514,7 @@ namespace ControlAbonados.Data
                             where pegue.EstadoPegue.NombreEstadoPegue.StartsWith(buscar)
                             group pegue by new
                             {
+                                pegue.Abonado.IdAbonado,
                                 pegue.Abonado.NumIdentidad,
                                 pegue.Abonado.Nombres,
                                 pegue.Abonado.Apellidos,
@@ -180,6 +526,7 @@ namespace ControlAbonados.Data
                             } into pegues
                             select new
                             {
+                                N = pegues.Key.IdAbonado,
                                 Identidad = pegues.Key.NumIdentidad,
                                 Nombre = pegues.Key.Nombres.ToUpper() + " " + pegues.Key.Apellidos.ToUpper(),
                                 Bloque = pegues.Key.NumeroBloque,
@@ -286,7 +633,7 @@ namespace ControlAbonados.Data
                     from mes in ctx.Mes
                     orderby mes.IdMes
                     select new { mes.IdMes, mes.NombreMes}
-                ).ToList();
+                ).Take(12).ToList();
             cbo.DisplayMember = "NombreMes";
             cbo.ValueMember = "IdMes";
         }
diff --git a/Visual proyect/ControlAbonados/ControlAbonados/Forms/Abonados.Designer.cs b/Visual proyect/ControlAbonados/ControlAbonados/Forms/Abonados.Designer.cs
index dce7ad6..e8528df 100644
--- a/Visual proyect/ControlAbonados/ControlAbonados/Forms/Abonados.Designer.cs	
+++ b/Visual proyect/ControlAbonados/ControlAbonados/Forms/Abonados.Designer.cs	
@@ -30,9 +30,9 @@ namespace ControlAbonados.Forms
         private void InitializeComponent()
         {
             this.components = new System.ComponentModel.Container();
-            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
-            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
-            BunifuAnimatorNS.Animation animation3 = new BunifuAnimatorNS.Animation();
+            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
+            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
+            BunifuAnimatorNS.Animation animation2 = new BunifuAnimatorNS.Animation();
             System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Abonados));
             this.pnlSideBar = new System.Windows.Forms.Panel();
             this.pnlListados = new System.Windows.Forms.Panel();
@@ -46,6 +46,9 @@ namespace ControlAbonados.Forms
             this.lblAbonados = new System.Windows.Forms.Label();
             this.tabAbonados = new System.Windows.Forms.TabControl();
             this.tabPage1 = new System.Windows.Forms.TabPage();
+            this.button1 = new System.Windows.Forms.Button();
+            this.lblIdAbonadoEdicion = new System.Windows.Forms.Label();
+            this.btnGuardarAbonadoEditado = new System.Windows.Forms.Button();
             this.lblNombreCant = new System.Windows.Forms.Label();
             this.btnGuardarAbonado = new System.Windows.Forms.Button();
             this.pnlCantPegues = new System.Windows.Forms.Panel();
@@ -63,6 +66,8 @@ namespace ControlAbonados.Forms
             this.label4 = new System.Windows.Forms.Label();
             this.lblTituloAbonados = new System.Windows.Forms.Label();
             this.tabPage2 = new System.Windows.Forms.TabPage();
+            this.lblCodPegue = new System.Windows.Forms.Label();
+            this.lblCantidadPegues = new System.Windows.Forms.Label();
             this.lblIdAbonado = new System.Windows.Forms.Label();
             this.lblGuardandoPegue = new System.Windows.Forms.Label();
             this.label7 = new System.Windows.Forms.Label();
@@ -110,17 +115,25 @@ namespace ControlAbonados.Forms
             this.lblTitulo = new System.Windows.Forms.Label();
             this.btnGuardarPegue = new System.Windows.Forms.Button();
             this.tabPage3 = new System.Windows.Forms.TabPage();
+            this.label9 = new System.Windows.Forms.Label();
+            this.lblCancelarFiltro = new System.Windows.Forms.Label();
+            this.cboTipoBusqueda = new System.Windows.Forms.ComboBox();
             this.btnGenerarReporte = new System.Windows.Forms.Label();
             this.btnAddAbonado = new System.Windows.Forms.Label();
             this.btnEditarPegue = new System.Windows.Forms.Label();
             this.btnEditarAbonado = new System.Windows.Forms.Label();
             this.dgvListados = new System.Windows.Forms.DataGridView();
             this.pnlBusqueda = new System.Windows.Forms.Panel();
+            this.cboBusquedas = new System.Windows.Forms.ComboBox();
             this.txtBusqueda = new System.Windows.Forms.TextBox();
             this.label21 = new System.Windows.Forms.Label();
+            this.tabPage4 = new System.Windows.Forms.TabPage();
             this.bunifuTransition1 = new BunifuAnimatorNS.BunifuTransition(this.components);
             this.errorAbonado = new System.Windows.Forms.ErrorProvider(this.components);
-            this.lblCantidadPegues = new System.Windows.Forms.Label();
+            this.lblCantMesesPagados = new System.Windows.Forms.Label();
+            this.label13 = new System.Windows.Forms.Label();
+            this.panel1 = new System.Windows.Forms.Panel();
+            this.txtNota = new System.Windows.Forms.TextBox();
             this.btnQuitarMes = new System.Windows.Forms.PictureBox();
             this.btnAddMes = new System.Windows.Forms.PictureBox();
             this.btnBusqueda = new System.Windows.Forms.PictureBox();
@@ -128,9 +141,6 @@ namespace ControlAbonados.Forms
             this.pictureBox4 = new System.Windows.Forms.PictureBox();
             this.pictureBox3 = new System.Windows.Forms.PictureBox();
             this.btnMenu = new System.Windows.Forms.PictureBox();
-            this.cboTipoBusqueda = new System.Windows.Forms.ComboBox();
-            this.cboBusquedas = new System.Windows.Forms.ComboBox();
-            this.lblCancelarFiltro = new System.Windows.Forms.Label();
             this.pnlSideBar.SuspendLayout();
             this.pnlListados.SuspendLayout();
             this.pnlPegues.SuspendLayout();
@@ -162,6 +172,7 @@ namespace ControlAbonados.Forms
             ((System.ComponentModel.ISupportInitialize)(this.dgvListados)).BeginInit();
             this.pnlBusqueda.SuspendLayout();
             ((System.ComponentModel.ISupportInitialize)(this.errorAbonado)).BeginInit();
+            this.panel1.SuspendLayout();
             ((System.ComponentModel.ISupportInitialize)(this.btnQuitarMes)).BeginInit();
             ((System.ComponentModel.ISupportInitialize)(this.btnAddMes)).BeginInit();
             ((System.ComponentModel.ISupportInitialize)(this.btnBusqueda)).BeginInit();
@@ -306,6 +317,7 @@ namespace ControlAbonados.Forms
             this.tabAbonados.Controls.Add(this.tabPage1);
             this.tabAbonados.Controls.Add(this.tabPage2);
             this.tabAbonados.Controls.Add(this.tabPage3);
+            this.tabAbonados.Controls.Add(this.tabPage4);
             this.bunifuTransition1.SetDecoration(this.tabAbonados, BunifuAnimatorNS.DecorationType.None);
             this.tabAbonados.Location = new System.Drawing.Point(248, 0);
             this.tabAbonados.Name = "tabAbonados";
@@ -316,6 +328,9 @@ namespace ControlAbonados.Forms
             // tabPage1
             // 
             this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
+            this.tabPage1.Controls.Add(this.button1);
+            this.tabPage1.Controls.Add(this.lblIdAbonadoEdicion);
+            this.tabPage1.Controls.Add(this.btnGuardarAbonadoEditado);
             this.tabPage1.Controls.Add(this.lblNombreCant);
             this.tabPage1.Controls.Add(this.btnGuardarAbonado);
             this.tabPage1.Controls.Add(this.pnlCantPegues);
@@ -337,6 +352,54 @@ namespace ControlAbonados.Forms
             this.tabPage1.TabIndex = 0;
             this.tabPage1.Text = "tabPage1";
             // 
+            // button1
+            // 
+            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
+            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
+            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
+            this.bunifuTransition1.SetDecoration(this.button1, BunifuAnimatorNS.DecorationType.None);
+            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
+            this.button1.Font = new System.Drawing.Font("Product Sans Black", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
+            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
+            this.button1.Location = new System.Drawing.Point(38, 601);
+            this.button1.Name = "button1";
+            this.button1.Size = new System.Drawing.Size(200, 70);
+            this.button1.TabIndex = 17;
+            this.button1.Text = "Cancelar";
+            this.button1.UseVisualStyleBackColor = false;
+            this.button1.Click += new System.EventHandler(this.button1_Click);
+            // 
+            // lblIdAbonadoEdicion
+            // 
+            this.lblIdAbonadoEdicion.AutoSize = true;
+            this.bunifuTransition1.SetDecoration(this.lblIdAbonadoEdicion, BunifuAnimatorNS.DecorationType.None);
+            this.lblIdAbonadoEdicion.Font = new System.Drawing.Font("Product Sans", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
+            this.lblIdAbonadoEdicion.Location = new System.Drawing.Point(967, 41);
+            this.lblIdAbonadoEdicion.Name = "lblIdAbonadoEdicion";
+            this.lblIdAbonadoEdicion.Size = new System.Drawing.Size(91, 25);
+            this.lblIdAbonadoEdicion.TabIndex = 16;
+            this.lblIdAbonadoEdicion.Text = "Apellidos";
+            this.lblIdAbonadoEdicion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
+            this.lblIdAbonadoEdicion.Visible = false;
+            // 
+            // btnGuardarAbonadoEditado
+            // 
+            this.btnGuardarAbonadoEditado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
+            this.btnGuardarAbonadoEditado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
+            this.btnGuardarAbonadoEditado.Cursor = System.Windows.Forms.Cursors.Hand;
+            this.bunifuTransition1.SetDecoration(this.btnGuardarAbonadoEditado, BunifuAnimatorNS.DecorationType.None);
+            this.btnGuardarAbonadoEditado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
+            this.btnGuardarAbonadoEditado.Font = new System.Drawing.Font("Product Sans Black", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
+            this.btnGuardarAbonadoEditado.ForeColor = System.Drawing.Color.White;
+            this.btnGuardarAbonadoEditado.Location = new System.Drawing.Point(858, 601);
+            this.btnGuardarAbonadoEditado.Name = "btnGuardarAbonadoEditado";
+            this.btnGuardarAbonadoEditado.Size = new System.Drawing.Size(200, 70);
+            this.btnGuardarAbonadoEditado.TabIndex = 15;
+            this.btnGuardarAbonadoEditado.Text = "Guardar abonado";
+            this.btnGuardarAbonadoEditado.UseVisualStyleBackColor = false;
+            this.btnGuardarAbonadoEditado.Visible = false;
+            this.btnGuardarAbonadoEditado.Click += new System.EventHandler(this.btnGuardarAbonadoEditado_Click);
+            // 
             // lblNombreCant
             // 
             this.lblNombreCant.AutoSize = true;
@@ -371,7 +434,7 @@ namespace ControlAbonados.Forms
             this.pnlCantPegues.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
             this.pnlCantPegues.Controls.Add(this.numCantPegues);
             this.bunifuTransition1.SetDecoration(this.pnlCantPegues, BunifuAnimatorNS.DecorationType.None);
-            this.pnlCantPegues.Location = new System.Drawing.Point(46, 405);
+            this.pnlCantPegues.Location = new System.Drawing.Point(38, 405);
             this.pnlCantPegues.Name = "pnlCantPegues";
             this.pnlCantPegues.Size = new System.Drawing.Size(450, 40);
             this.pnlCantPegues.TabIndex = 10;
@@ -529,6 +592,10 @@ namespace ControlAbonados.Forms
             // tabPage2
             // 
             this.tabPage2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
+            this.tabPage2.Controls.Add(this.panel1);
+            this.tabPage2.Controls.Add(this.label13);
+            this.tabPage2.Controls.Add(this.lblCantMesesPagados);
+            this.tabPage2.Controls.Add(this.lblCodPegue);
             this.tabPage2.Controls.Add(this.lblCantidadPegues);
             this.tabPage2.Controls.Add(this.lblIdAbonado);
             this.tabPage2.Controls.Add(this.lblGuardandoPegue);
@@ -576,6 +643,28 @@ namespace ControlAbonados.Forms
             this.tabPage2.TabIndex = 1;
             this.tabPage2.Text = "tabPage2";
             // 
+            // lblCodPegue
+            // 
+            this.lblCodPegue.AutoSize = true;
+            this.bunifuTransition1.SetDecoration(this.lblCodPegue, BunifuAnimatorNS.DecorationType.None);
+            this.lblCodPegue.Font = new System.Drawing.Font("Product Sans", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
+            this.lblCodPegue.Location = new System.Drawing.Point(175, 66);
+            this.lblCodPegue.Name = "lblCodPegue";
+            this.lblCodPegue.Size = new System.Drawing.Size(65, 18);
+            this.lblCodPegue.TabIndex = 44;
+            this.lblCodPegue.Text = "Nombres";
+            // 
+            // lblCantidadPegues
+            // 
+            this.lblCantidadPegues.AutoSize = true;
+            this.bunifuTransition1.SetDecoration(this.lblCantidadPegues, BunifuAnimatorNS.DecorationType.None);
+            this.lblCantidadPegues.Font = new System.Drawing.Font("Product Sans", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
+            this.lblCantidadPegues.Location = new System.Drawing.Point(104, 66);
+            this.lblCantidadPegues.Name = "lblCantidadPegues";
+            this.lblCantidadPegues.Size = new System.Drawing.Size(65, 18);
+            this.lblCantidadPegues.TabIndex = 43;
+            this.lblCantidadPegues.Text = "Nombres";
+            // 
             // lblIdAbonado
             // 
             this.lblIdAbonado.AutoSize = true;
@@ -745,7 +834,7 @@ namespace ControlAbonados.Forms
             this.btnSiguientePegue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
             this.btnSiguientePegue.Font = new System.Drawing.Font("Product Sans Black", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
             this.btnSiguientePegue.ForeColor = System.Drawing.Color.White;
-            this.btnSiguientePegue.Location = new System.Drawing.Point(846, 588);
+            this.btnSiguientePegue.Location = new System.Drawing.Point(847, 587);
             this.btnSiguientePegue.Name = "btnSiguientePegue";
             this.btnSiguientePegue.Size = new System.Drawing.Size(200, 70);
             this.btnSiguientePegue.TabIndex = 30;
@@ -1126,17 +1215,19 @@ namespace ControlAbonados.Forms
             this.btnGuardarPegue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
             this.btnGuardarPegue.Font = new System.Drawing.Font("Product Sans Black", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
             this.btnGuardarPegue.ForeColor = System.Drawing.Color.White;
-            this.btnGuardarPegue.Location = new System.Drawing.Point(463, 429);
+            this.btnGuardarPegue.Location = new System.Drawing.Point(846, 588);
             this.btnGuardarPegue.Name = "btnGuardarPegue";
             this.btnGuardarPegue.Size = new System.Drawing.Size(200, 70);
             this.btnGuardarPegue.TabIndex = 35;
             this.btnGuardarPegue.Text = "Guardar pegues";
             this.btnGuardarPegue.UseVisualStyleBackColor = false;
             this.btnGuardarPegue.Visible = false;
+            this.btnGuardarPegue.Click += new System.EventHandler(this.btnGuardarPegue_Click);
             // 
             // tabPage3
             // 
             this.tabPage3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
+            this.tabPage3.Controls.Add(this.label9);
             this.tabPage3.Controls.Add(this.lblCancelarFiltro);
             this.tabPage3.Controls.Add(this.cboTipoBusqueda);
             this.tabPage3.Controls.Add(this.btnGenerarReporte);
@@ -1154,16 +1245,63 @@ namespace ControlAbonados.Forms
             this.tabPage3.TabIndex = 2;
             this.tabPage3.Text = "tabPage3";
             // 
+            // label9
+            // 
+            this.label9.AutoSize = true;
+            this.label9.Cursor = System.Windows.Forms.Cursors.Hand;
+            this.bunifuTransition1.SetDecoration(this.label9, BunifuAnimatorNS.DecorationType.None);
+            this.label9.Font = new System.Drawing.Font("Product Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
+            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
+            this.label9.Location = new System.Drawing.Point(555, 96);
+            this.label9.Name = "label9";
+            this.label9.Size = new System.Drawing.Size(82, 20);
+            this.label9.TabIndex = 15;
+            this.label9.Text = "Ver pegue";
+            // 
+            // lblCancelarFiltro
+            // 
+            this.lblCancelarFiltro.AutoSize = true;
+            this.lblCancelarFiltro.Cursor = System.Windows.Forms.Cursors.Hand;
+            this.bunifuTransition1.SetDecoration(this.lblCancelarFiltro, BunifuAnimatorNS.DecorationType.None);
+            this.lblCancelarFiltro.Font = new System.Drawing.Font("Product Sans", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
+            this.lblCancelarFiltro.ForeColor = System.Drawing.Color.IndianRed;
+            this.lblCancelarFiltro.Location = new System.Drawing.Point(926, 75);
+            this.lblCancelarFiltro.Name = "lblCancelarFiltro";
+            this.lblCancelarFiltro.Size = new System.Drawing.Size(127, 18);
+            this.lblCancelarFiltro.TabIndex = 14;
+            this.lblCancelarFiltro.Text = "Cancelar busqueda";
+            this.lblCancelarFiltro.Click += new System.EventHandler(this.lblCancelarFiltro_Click);
+            // 
+            // cboTipoBusqueda
+            // 
+            this.cboTipoBusqueda.BackColor = System.Drawing.Color.White;
+            this.bunifuTransition1.SetDecoration(this.cboTipoBusqueda, BunifuAnimatorNS.DecorationType.None);
+            this.cboTipoBusqueda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
+            this.cboTipoBusqueda.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
+            this.cboTipoBusqueda.Font = new System.Drawing.Font("Product Sans", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
+            this.cboTipoBusqueda.FormattingEnabled = true;
+            this.cboTipoBusqueda.Items.AddRange(new object[] {
+            "Nombre",
+            "Bloque",
+            "Casa",
+            "Mes",
+            "Estado"});
+            this.cboTipoBusqueda.Location = new System.Drawing.Point(733, 94);
+            this.cboTipoBusqueda.Name = "cboTipoBusqueda";
+            this.cboTipoBusqueda.Size = new System.Drawing.Size(320, 29);
+            this.cboTipoBusqueda.TabIndex = 13;
+            this.cboTipoBusqueda.SelectedIndexChanged += new System.EventHandler(this.cboTipoBusqueda_SelectedIndexChanged);
+            // 
             // btnGenerarReporte
             // 
             this.btnGenerarReporte.AutoSize = true;
             this.btnGenerarReporte.Cursor = System.Windows.Forms.Cursors.Hand;
             this.bunifuTransition1.SetDecoration(this.btnGenerarReporte, BunifuAnimatorNS.DecorationType.None);
-            this.btnGenerarReporte.Font = new System.Drawing.Font("Product Sans", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
+            this.btnGenerarReporte.Font = new System.Drawing.Font("Product Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
             this.btnGenerarReporte.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
-            this.btnGenerarReporte.Location = new System.Drawing.Point(534, 94);
+            this.btnGenerarReporte.Location = new System.Drawing.Point(422, 94);
             this.btnGenerarReporte.Name = "btnGenerarReporte";
-            this.btnGenerarReporte.Size = new System.Drawing.Size(154, 25);
+            this.btnGenerarReporte.Size = new System.Drawing.Size(127, 20);
             this.btnGenerarReporte.TabIndex = 12;
             this.btnGenerarReporte.Text = "Generar reporte";
             // 
@@ -1172,11 +1310,11 @@ namespace ControlAbonados.Forms
             this.btnAddAbonado.AutoSize = true;
             this.btnAddAbonado.Cursor = System.Windows.Forms.Cursors.Hand;
             this.bunifuTransition1.SetDecoration(this.btnAddAbonado, BunifuAnimatorNS.DecorationType.None);
-            this.btnAddAbonado.Font = new System.Drawing.Font("Product Sans", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
+            this.btnAddAbonado.Font = new System.Drawing.Font("Product Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
             this.btnAddAbonado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
-            this.btnAddAbonado.Location = new System.Drawing.Point(329, 94);
+            this.btnAddAbonado.Location = new System.Drawing.Point(261, 94);
             this.btnAddAbonado.Name = "btnAddAbonado";
-            this.btnAddAbonado.Size = new System.Drawing.Size(189, 25);
+            this.btnAddAbonado.Size = new System.Drawing.Size(155, 20);
             this.btnAddAbonado.TabIndex = 11;
             this.btnAddAbonado.Text = "Añadir otro abonado";
             // 
@@ -1185,50 +1323,52 @@ namespace ControlAbonados.Forms
             this.btnEditarPegue.AutoSize = true;
             this.btnEditarPegue.Cursor = System.Windows.Forms.Cursors.Hand;
             this.bunifuTransition1.SetDecoration(this.btnEditarPegue, BunifuAnimatorNS.DecorationType.None);
-            this.btnEditarPegue.Font = new System.Drawing.Font("Product Sans", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
+            this.btnEditarPegue.Font = new System.Drawing.Font("Product Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
             this.btnEditarPegue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
-            this.btnEditarPegue.Location = new System.Drawing.Point(188, 94);
+            this.btnEditarPegue.Location = new System.Drawing.Point(155, 94);
             this.btnEditarPegue.Name = "btnEditarPegue";
-            this.btnEditarPegue.Size = new System.Drawing.Size(123, 25);
+            this.btnEditarPegue.Size = new System.Drawing.Size(100, 20);
             this.btnEditarPegue.TabIndex = 10;
             this.btnEditarPegue.Text = "Editar pegue";
+            this.btnEditarPegue.Click += new System.EventHandler(this.btnEditarPegue_Click);
             // 
             // btnEditarAbonado
             // 
             this.btnEditarAbonado.AutoSize = true;
             this.btnEditarAbonado.Cursor = System.Windows.Forms.Cursors.Hand;
             this.bunifuTransition1.SetDecoration(this.btnEditarAbonado, BunifuAnimatorNS.DecorationType.None);
-            this.btnEditarAbonado.Font = new System.Drawing.Font("Product Sans", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
+            this.btnEditarAbonado.Font = new System.Drawing.Font("Product Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
             this.btnEditarAbonado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
             this.btnEditarAbonado.Location = new System.Drawing.Point(33, 94);
             this.btnEditarAbonado.Name = "btnEditarAbonado";
-            this.btnEditarAbonado.Size = new System.Drawing.Size(144, 25);
+            this.btnEditarAbonado.Size = new System.Drawing.Size(116, 20);
             this.btnEditarAbonado.TabIndex = 9;
             this.btnEditarAbonado.Text = "Editar abonado";
+            this.btnEditarAbonado.Click += new System.EventHandler(this.btnEditarAbonado_Click);
             // 
             // dgvListados
             // 
             this.dgvListados.AllowUserToAddRows = false;
             this.dgvListados.AllowUserToDeleteRows = false;
-            this.dgvListados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
-            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
-            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
-            dataGridViewCellStyle5.Font = new System.Drawing.Font("Product Sans Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
-            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
-            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
-            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
-            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
-            this.dgvListados.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
+            this.dgvListados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
+            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
+            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
+            dataGridViewCellStyle3.Font = new System.Drawing.Font("Product Sans Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
+            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
+            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
+            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
+            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
+            this.dgvListados.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
             this.dgvListados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
             this.bunifuTransition1.SetDecoration(this.dgvListados, BunifuAnimatorNS.DecorationType.None);
-            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
-            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
-            dataGridViewCellStyle6.Font = new System.Drawing.Font("Product Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
-            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
-            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
-            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
-            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
-            this.dgvListados.DefaultCellStyle = dataGridViewCellStyle6;
+            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
+            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
+            dataGridViewCellStyle4.Font = new System.Drawing.Font("Product Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
+            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
+            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
+            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
+            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
+            this.dgvListados.DefaultCellStyle = dataGridViewCellStyle4;
             this.dgvListados.Location = new System.Drawing.Point(38, 140);
             this.dgvListados.MultiSelect = false;
             this.dgvListados.Name = "dgvListados";
@@ -1251,6 +1391,20 @@ namespace ControlAbonados.Forms
             this.pnlBusqueda.Size = new System.Drawing.Size(320, 40);
             this.pnlBusqueda.TabIndex = 7;
             // 
+            // cboBusquedas
+            // 
+            this.cboBusquedas.BackColor = System.Drawing.Color.White;
+            this.bunifuTransition1.SetDecoration(this.cboBusquedas, BunifuAnimatorNS.DecorationType.None);
+            this.cboBusquedas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
+            this.cboBusquedas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
+            this.cboBusquedas.Font = new System.Drawing.Font("Product Sans", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
+            this.cboBusquedas.FormattingEnabled = true;
+            this.cboBusquedas.Location = new System.Drawing.Point(6, 4);
+            this.cboBusquedas.Name = "cboBusquedas";
+            this.cboBusquedas.Size = new System.Drawing.Size(273, 29);
+            this.cboBusquedas.TabIndex = 6;
+            this.cboBusquedas.SelectedIndexChanged += new System.EventHandler(this.cboBusquedas_SelectedIndexChanged);
+            // 
             // txtBusqueda
             // 
             this.txtBusqueda.BackColor = System.Drawing.Color.White;
@@ -1275,41 +1429,86 @@ namespace ControlAbonados.Forms
             this.label21.TabIndex = 6;
             this.label21.Text = "Listado de abonados";
             // 
+            // tabPage4
+            // 
+            this.bunifuTransition1.SetDecoration(this.tabPage4, BunifuAnimatorNS.DecorationType.None);
+            this.tabPage4.Location = new System.Drawing.Point(4, 22);
+            this.tabPage4.Name = "tabPage4";
+            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
+            this.tabPage4.Size = new System.Drawing.Size(1098, 701);
+            this.tabPage4.TabIndex = 3;
+            this.tabPage4.Text = "tabPage4";
+            this.tabPage4.UseVisualStyleBackColor = true;
+            // 
             // bunifuTransition1
             // 
             this.bunifuTransition1.AnimationType = BunifuAnimatorNS.AnimationType.VertSlide;
             this.bunifuTransition1.Cursor = null;
-            animation3.AnimateOnlyDifferences = true;
-            animation3.BlindCoeff = ((System.Drawing.PointF)(resources.GetObject("animation3.BlindCoeff")));
-            animation3.LeafCoeff = 0F;
-            animation3.MaxTime = 1F;
-            animation3.MinTime = 0F;
-            animation3.MosaicCoeff = ((System.Drawing.PointF)(resources.GetObject("animation3.MosaicCoeff")));
-            animation3.MosaicShift = ((System.Drawing.PointF)(resources.GetObject("animation3.MosaicShift")));
-            animation3.MosaicSize = 0;
-            animation3.Padding = new System.Windows.Forms.Padding(0);
-            animation3.RotateCoeff = 0F;
-            animation3.RotateLimit = 0F;
-            animation3.ScaleCoeff = ((System.Drawing.PointF)(resources.GetObject("animation3.ScaleCoeff")));
-            animation3.SlideCoeff = ((System.Drawing.PointF)(resources.GetObject("animation3.SlideCoeff")));
-            animation3.TimeCoeff = 0F;
-            animation3.TransparencyCoeff = 0F;
-            this.bunifuTransition1.DefaultAnimation = animation3;
+            animation2.AnimateOnlyDifferences = true;
+            animation2.BlindCoeff = ((System.Drawing.PointF)(resources.GetObject("animation2.BlindCoeff")));
+            animation2.LeafCoeff = 0F;
+            animation2.MaxTime = 1F;
+            animation2.MinTime = 0F;
+            animation2.MosaicCoeff = ((System.Drawing.PointF)(resources.GetObject("animation2.MosaicCoeff")));
+            animation2.MosaicShift = ((System.Drawing.PointF)(resources.GetObject("animation2.MosaicShift")));
+            animation2.MosaicSize = 0;
+            animation2.Padding = new System.Windows.Forms.Padding(0);
+            animation2.RotateCoeff = 0F;
+            animation2.RotateLimit = 0F;
+            animation2.ScaleCoeff = ((System.Drawing.PointF)(resources.GetObject("animation2.ScaleCoeff")));
+            animation2.SlideCoeff = ((System.Drawing.PointF)(resources.GetObject("animation2.SlideCoeff")));
+            animation2.TimeCoeff = 0F;
+            animation2.TransparencyCoeff = 0F;
+            this.bunifuTransition1.DefaultAnimation = animation2;
             // 
             // errorAbonado
             // 
             this.errorAbonado.ContainerControl = this;
             // 
-            // lblCantidadPegues
-            // 
-            this.lblCantidadPegues.AutoSize = true;
-            this.bunifuTransition1.SetDecoration(this.lblCantidadPegues, BunifuAnimatorNS.DecorationType.None);
-            this.lblCantidadPegues.Font = new System.Drawing.Font("Product Sans", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
-            this.lblCantidadPegues.Location = new System.Drawing.Point(104, 66);
-            this.lblCantidadPegues.Name = "lblCantidadPegues";
-            this.lblCantidadPegues.Size = new System.Drawing.Size(65, 18);
-            this.lblCantidadPegues.TabIndex = 43;
-            this.lblCantidadPegues.Text = "Nombres";
+            // lblCantMesesPagados
+            // 
+            this.lblCantMesesPagados.AutoSize = true;
+            this.bunifuTransition1.SetDecoration(this.lblCantMesesPagados, BunifuAnimatorNS.DecorationType.None);
+            this.lblCantMesesPagados.Font = new System.Drawing.Font("Product Sans", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
+            this.lblCantMesesPagados.Location = new System.Drawing.Point(246, 68);
+            this.lblCantMesesPagados.Name = "lblCantMesesPagados";
+            this.lblCantMesesPagados.Size = new System.Drawing.Size(65, 18);
+            this.lblCantMesesPagados.TabIndex = 45;
+            this.lblCantMesesPagados.Text = "Nombres";
+            // 
+            // label13
+            // 
+            this.label13.AutoSize = true;
+            this.bunifuTransition1.SetDecoration(this.label13, BunifuAnimatorNS.DecorationType.None);
+            this.label13.Font = new System.Drawing.Font("Product Sans", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
+            this.label13.Location = new System.Drawing.Point(458, 415);
+            this.label13.Name = "label13";
+            this.label13.Size = new System.Drawing.Size(54, 25);
+            this.label13.TabIndex = 46;
+            this.label13.Text = "Nota";
+            // 
+            // panel1
+            // 
+            this.panel1.BackColor = System.Drawing.Color.White;
+            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
+            this.panel1.Controls.Add(this.txtNota);
+            this.bunifuTransition1.SetDecoration(this.panel1, BunifuAnimatorNS.DecorationType.None);
+            this.panel1.Location = new System.Drawing.Point(463, 443);
+            this.panel1.Name = "panel1";
+            this.panel1.Size = new System.Drawing.Size(320, 93);
+            this.panel1.TabIndex = 47;
+            // 
+            // txtNota
+            // 
+            this.txtNota.BackColor = System.Drawing.Color.White;
+            this.txtNota.BorderStyle = System.Windows.Forms.BorderStyle.None;
+            this.bunifuTransition1.SetDecoration(this.txtNota, BunifuAnimatorNS.DecorationType.None);
+            this.txtNota.Font = new System.Drawing.Font("Product Sans", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
+            this.txtNota.Location = new System.Drawing.Point(6, 8);
+            this.txtNota.Multiline = true;
+            this.txtNota.Name = "txtNota";
+            this.txtNota.Size = new System.Drawing.Size(305, 80);
+            this.txtNota.TabIndex = 0;
             // 
             // btnQuitarMes
             // 
@@ -1396,55 +1595,6 @@ namespace ControlAbonados.Forms
             this.btnMenu.MouseLeave += new System.EventHandler(this.pnlMenu_MouseLeave);
             this.btnMenu.MouseHover += new System.EventHandler(this.pnlMenu_MouseHover);
             // 
-            // cboTipoBusqueda
-            // 
-            this.cboTipoBusqueda.BackColor = System.Drawing.Color.White;
-            this.bunifuTransition1.SetDecoration(this.cboTipoBusqueda, BunifuAnimatorNS.DecorationType.None);
-            this.cboTipoBusqueda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
-            this.cboTipoBusqueda.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
-            this.cboTipoBusqueda.Font = new System.Drawing.Font("Product Sans", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
-            this.cboTipoBusqueda.FormattingEnabled = true;
-            this.cboTipoBusqueda.Items.AddRange(new object[] {
-            "Aplicar filtro",
-            "Nombre",
-            "Bloque",
-            "Casa",
-            "Mes",
-            "Estado"});
-            this.cboTipoBusqueda.Location = new System.Drawing.Point(733, 94);
-            this.cboTipoBusqueda.Name = "cboTipoBusqueda";
-            this.cboTipoBusqueda.Size = new System.Drawing.Size(320, 29);
-            this.cboTipoBusqueda.TabIndex = 13;
-            this.cboTipoBusqueda.SelectedIndexChanged += new System.EventHandler(this.cboTipoBusqueda_SelectedIndexChanged);
-            // 
-            // cboBusquedas
-            // 
-            this.cboBusquedas.BackColor = System.Drawing.Color.White;
-            this.bunifuTransition1.SetDecoration(this.cboBusquedas, BunifuAnimatorNS.DecorationType.None);
-            this.cboBusquedas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
-            this.cboBusquedas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
-            this.cboBusquedas.Font = new System.Drawing.Font("Product Sans", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
-            this.cboBusquedas.FormattingEnabled = true;
-            this.cboBusquedas.Location = new System.Drawing.Point(6, 4);
-            this.cboBusquedas.Name = "cboBusquedas";
-            this.cboBusquedas.Size = new System.Drawing.Size(273, 29);
-            this.cboBusquedas.TabIndex = 6;
-            this.cboBusquedas.SelectedIndexChanged += new System.EventHandler(this.cboBusquedas_SelectedIndexChanged);
-            // 
-            // lblCancelarFiltro
-            // 
-            this.lblCancelarFiltro.AutoSize = true;
-            this.lblCancelarFiltro.Cursor = System.Windows.Forms.Cursors.Hand;
-            this.bunifuTransition1.SetDecoration(this.lblCancelarFiltro, BunifuAnimatorNS.DecorationType.None);
-            this.lblCancelarFiltro.Font = new System.Drawing.Font("Product Sans", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
-            this.lblCancelarFiltro.ForeColor = System.Drawing.Color.IndianRed;
-            this.lblCancelarFiltro.Location = new System.Drawing.Point(926, 75);
-            this.lblCancelarFiltro.Name = "lblCancelarFiltro";
-            this.lblCancelarFiltro.Size = new System.Drawing.Size(127, 18);
-            this.lblCancelarFiltro.TabIndex = 14;
-            this.lblCancelarFiltro.Text = "Cancelar busqueda";
-            this.lblCancelarFiltro.Click += new System.EventHandler(this.lblCancelarFiltro_Click);
-            // 
             // Abonados
             // 
             this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
@@ -1502,6 +1652,8 @@ namespace ControlAbonados.Forms
             this.pnlBusqueda.ResumeLayout(false);
             this.pnlBusqueda.PerformLayout();
             ((System.ComponentModel.ISupportInitialize)(this.errorAbonado)).EndInit();
+            this.panel1.ResumeLayout(false);
+            this.panel1.PerformLayout();
             ((System.ComponentModel.ISupportInitialize)(this.btnQuitarMes)).EndInit();
             ((System.ComponentModel.ISupportInitialize)(this.btnAddMes)).EndInit();
             ((System.ComponentModel.ISupportInitialize)(this.btnBusqueda)).EndInit();
@@ -1538,7 +1690,6 @@ namespace ControlAbonados.Forms
         private System.Windows.Forms.Panel panel6;
         private System.Windows.Forms.Panel pnlApellidos;
         private System.Windows.Forms.TextBox txtApellidos;
-        private System.Windows.Forms.Label label6;
         private System.Windows.Forms.Panel pnlNumIdentidad;
         private System.Windows.Forms.Label label5;
         private System.Windows.Forms.Panel pnlNombres;
@@ -1612,5 +1763,16 @@ namespace ControlAbonados.Forms
         private System.Windows.Forms.ComboBox cboTipoBusqueda;
         private System.Windows.Forms.ComboBox cboBusquedas;
         private System.Windows.Forms.Label lblCancelarFiltro;
+        private System.Windows.Forms.TabPage tabPage4;
+        private System.Windows.Forms.Label label9;
+        private System.Windows.Forms.Button btnGuardarAbonadoEditado;
+        private System.Windows.Forms.Label lblIdAbonadoEdicion;
+        private System.Windows.Forms.Label label6;
+        private System.Windows.Forms.Button button1;
+        private System.Windows.Forms.Label lblCodPegue;
+        private System.Windows.Forms.Label lblCantMesesPagados;
+        private System.Windows.Forms.Panel panel1;
+        private System.Windows.Forms.TextBox txtNota;
+        private System.Windows.Forms.Label label13;
     }
 }
\ No newline at end of file
diff --git a/Visual proyect/ControlAbonados/ControlAbonados/Forms/Abonados.cs b/Visual proyect/ControlAbonados/ControlAbonados/Forms/Abonados.cs
index b32630b..950f6ed 100644
--- a/Visual proyect/ControlAbonados/ControlAbonados/Forms/Abonados.cs	
+++ b/Visual proyect/ControlAbonados/ControlAbonados/Forms/Abonados.cs	
@@ -22,7 +22,7 @@ namespace ControlAbonados.Forms
         Color nombresColor;
 
         int cantPegues = 0;
-        int numeroPegueActual = 1;
+        int numeroPegueActual = 0;
 
         public Abonados()
         {
@@ -81,15 +81,232 @@ namespace ControlAbonados.Forms
                 return false;
             }
 
-            if (lsbMeses.Items.Count == 0)
+            /*if (lsbMeses.Items.Count == 0)
             {
                 errorAbonado.SetIconPadding(lblMesesPagados, 3);
                 errorAbonado.SetError(lblMesesPagados, "Ingrese un bloque correcto");
                 return false;
+            }*/
+            return true;
+        }
+
+        private void guardaPegueEditado()
+        {
+            string[] fechaEstadoPegue;
+
+            string nombres = txtNombreTab2.Text;
+            string apellidos = txtApellidosTab2.Text;
+            string numIdentidad = txtNumeroIdentidadTab2.Text;
+            string bloque = numBloque.Value.ToString();
+            string casa = numCasa.Value.ToString();
+            string tipoPegueNombre = cboTipoPegue.Text;
+            int tipoPegueID = cboTipoPegue.SelectedIndex + 1;
+            string estadoPegueNombre = cboEstado.Text;
+            int estadoPegueID = cboEstado.SelectedIndex + 1;
+            int cantidadMesesPagados = Convert.ToInt32(lblCantMesesPagados.Text);
+            string codPegue = lblCodPegue.Text;
+            int abonadoId = Convert.ToInt32(lblIdAbonado.Text);
+            string nota = txtNota.Text;
+
+            string mesEstado;
+            string yearEstado;
+            int mesEstadoID;
+
+
+            pgbPorcentajeAlmacenado.Enabled = true;
+            pgbPorcentajeAlmacenado.Visible = true;
+            pgbPorcentajeAlmacenado.Value = 25;
+            
+
+            string numeroIdentidad = DataAbonadoAccess.obtenerNumIdentidadByID(abonadoId);
+            int idTipoPegue = DataAbonadoAccess.obtenerTipoPegueIDPorNombre(tipoPegueNombre);
+            int idEstadoPegue = DataAbonadoAccess.obtenerEstadoPegueIDPorNombre(estadoPegueNombre);
+            bool tieneFechaEstadoPegue = DataAbonadoAccess.existeFechaEstadoPegue(codPegue);
+
+            if (tieneFechaEstadoPegue)
+            {
+                fechaEstadoPegue = DataAbonadoAccess.obtenerMesDeFechaControlPegue(codPegue);
+                mesEstado = cboMesEstado.Text;
+                yearEstado = numYearEstado.Value.ToString();
+                mesEstadoID = cboMesEstado.SelectedIndex + 1;
+
+                pgbPorcentajeAlmacenado.Value = 50;
+                
+                if(Convert.ToInt32(fechaEstadoPegue[4]) != estadoPegueID)
+                {
+                    if(estadoPegueID == 0)
+                    {
+                        DataAbonadoAccess.eliminarFechaEstadoPegue(codPegue);
+                    } else
+                    {
+                        DataAbonadoAccess.eliminarFechaEstadoPegue(codPegue);
+                        guardarFechaEstadoPegue(estadoPegueID, mesEstadoID, codPegue, yearEstado);
+                    }
+                }
+            } else
+            {
+                mesEstado = cboMesEstado.Text;
+                yearEstado = numYearEstado.Value.ToString();
+                mesEstadoID = cboMesEstado.SelectedIndex + 1;
+                guardarFechaEstadoPegue(estadoPegueID, mesEstadoID, codPegue, yearEstado);
+            }
+
+            
+
+            if(cantidadMesesPagados < lsbMeses.Items.Count)
+            {
+                cantidadMesesPagados = (cantidadMesesPagados == 0) ? 1: cantidadMesesPagados;
+                for(int i = cantidadMesesPagados; i <= lsbMeses.Items.Count; i++)
+                {
+                    guardarControlPago(codPegue, i);
+                }
+                pgbPorcentajeAlmacenado.Value = 75;
+            }
+
+            DataAbonadoAccess.actualizarPegue(codPegue, casa, tipoPegueID, estadoPegueID, Convert.ToInt32(bloque), nota);
+            pgbPorcentajeAlmacenado.Value = 100;
+            
+            pgbPorcentajeAlmacenado.Visible = false;
+            pgbPorcentajeAlmacenado.Value = 0;
+            resetearPegue();
+            resetearAbonadoEnPegue();
+
+            MessageBox.Show($"Pegue de {nombres} {apellidos} actualizado correctamente", "Pegue", MessageBoxButtons.OK);
+
+            seleccionarPanelListados();
+
+        }
+
+        private void eliminarFEP(string codPegue)
+        {
+            bool existeFEP = DataAbonadoAccess.existeFechaEstadoPegue(codPegue);
+            if (existeFEP)
+            {
+                DataAbonadoAccess.eliminarFechaEstadoPegue(codPegue);
+            }
+        }
+
+        /*
+         * funcion que añade meses de pago a un pegue
+         */
+        private void addMesPago(string codPegue)
+        {
+            int ultimoMesPago = DataAbonadoAccess.obtenerUltimoMesPagado(codPegue);
+
+            for(int i = ultimoMesPago; i <= lsbMeses.Items.Count; i++)
+            {
+                guardarControlPago(codPegue, i);
+            }
+        }
+
+        /*
+         * mueve los datos de la tabla de listado al tab de pegues
+         */
+        private void moverPegueAEdicion() {
+            string[] meses = {
+                "Enero",
+                "Febrero",
+                "Marzo",
+                "Abril",
+                "Mayo",
+                "Junio",
+                "Julio",
+                "Agosto",
+                "Septiembre",
+                "Octubre",
+                "Noviembre",
+                "Diciembre"
+            };
+            string[] fechaEstadoPegue;
+
+            string tipoPegue = dgvListados.CurrentRow.Cells[3].Value.ToString();
+            string bloque = dgvListados.CurrentRow.Cells[4].Value.ToString();
+            string casa = dgvListados.CurrentRow.Cells[5].Value.ToString();
+            string estadoPegue = dgvListados.CurrentRow.Cells[6].Value.ToString();
+            int cantidadMesesPagados = Convert.ToInt32(dgvListados.CurrentRow.Cells[7].Value);
+            int idAbonado = Convert.ToInt32(dgvListados.CurrentRow.Cells[0].Value);
+            string nombre = dgvListados.CurrentRow.Cells[1].Value.ToString();
+            string apellido = dgvListados.CurrentRow.Cells[2].Value.ToString();
+
+
+
+            string numeroIdentidad = DataAbonadoAccess.obtenerNumIdentidadByID(idAbonado);
+            int idTipoPegue = DataAbonadoAccess.obtenerTipoPegueIDPorNombre(tipoPegue);
+            int idEstadoPegue = DataAbonadoAccess.obtenerEstadoPegueIDPorNombre(estadoPegue);
+            string codiPegue = DataAbonadoAccess.obtenerCodigoPegueByPegue(bloque, casa);
+            bool tieneFechaEstadoPegue = DataAbonadoAccess.existeFechaEstadoPegue(codiPegue);           
+
+
+            if (tieneFechaEstadoPegue)
+            {
+                fechaEstadoPegue = DataAbonadoAccess.obtenerMesDeFechaControlPegue(codiPegue);
+                cboMesEstado.SelectedIndex = Convert.ToInt32(fechaEstadoPegue[0])-1;
+                numYearEstado.Value = Convert.ToInt32(fechaEstadoPegue[2]);
             }
+
+            lblCantMesesPagados.Text = cantidadMesesPagados.ToString();
+            numBloque.Value = Convert.ToInt32(bloque);
+            numCasa.Value = Convert.ToInt32(casa);
+            cboTipoPegue.SelectedIndex = idTipoPegue-1;
+            cboEstado.SelectedIndex = idEstadoPegue-1;
+            DataAbonadoAccess.excluirMes(cboMes, cantidadMesesPagados);
+            lblCodPegue.Text = codiPegue;
+            txtNombreTab2.Text = nombre;
+            txtApellidosTab2.Text = apellido;
+            txtNumeroIdentidadTab2.Text = numeroIdentidad;
+            lblIdAbonado.Text = idAbonado.ToString();
+
+            for(int i = 0; i < cantidadMesesPagados; i++)
+            {
+                lsbMeses.Items.Add(meses[i]);
+            }
+
+            btnSiguientePegue.Enabled = false;
+            btnSiguientePegue.Visible = false;
+            btnGuardarPegue.Enabled = true;
+            btnGuardarPegue.Visible = true;
+
+            seleccionarPanelPegues();
+        }
+
+        /*
+         * funcion para mover los datos desde la datagridview hasta el tab de abonados
+         */
+        private bool moverAbonadosAEdicion()
+        {
+            int idAbonado = Convert.ToInt32(dgvListados.CurrentRow.Cells[0].Value);
+            string nombre = dgvListados.CurrentRow.Cells[1].Value.ToString();
+            string apellido = dgvListados.CurrentRow.Cells[2].Value.ToString();
+            string numeroIdentidad = DataAbonadoAccess.obtenerNumIdentidadByID(idAbonado);
+
+            numCantPegues.Enabled = false;
+
+            lblIdAbonadoEdicion.Text = idAbonado.ToString();
+            txtNombres.Text = nombre;
+            txtApellidos.Text = apellido;
+            mTxtNumIdentidad.Text = numeroIdentidad;
+            btnGuardarAbonado.Enabled = false;
+            btnGuardarAbonado.Visible = false;
+            btnGuardarAbonadoEditado.Visible = true;
+
+            seleccionarPanelAbonado();
             return true;
         }
 
+
+        /*
+         * funcion para obtener editar un abonado
+         */
+        private void guardarAbonadoEditado()
+        {
+            string nombre = txtNombres.Text;
+            int idAbonado = Convert.ToInt32(lblIdAbonadoEdicion.Text);
+            string apellido = txtApellidos.Text;
+            string numeroIdentidad = (mTxtNumIdentidad.Text == "    -    -") ? "": mTxtNumIdentidad.Text;
+
+            DataAbonadoAccess.actualizarAbonado(idAbonado, nombre, apellido, numeroIdentidad);
+        }
+
         private void habilitarCboBusqueda(bool habilitar, string tipoBusqueda = "")
         {
             if (habilitar)
@@ -176,6 +393,8 @@ namespace ControlAbonados.Forms
                 string nombreAbonado = txtNombreTab2.Text;
                 string apellidoAbonado = txtApellidosTab2.Text;
 
+                string nota = txtNota.Text;
+
                 int indiceCboEstadoPegue = cboEstado.SelectedIndex;
 
                 pgbPorcentajeAlmacenado.Visible = true;
@@ -194,14 +413,19 @@ namespace ControlAbonados.Forms
                         tipoPegue,
                         estado,
                         bloque,
-                        casa);
+                        casa,
+                        nota);
                     pgbPorcentajeAlmacenado.Value = 50;
 
-                    // insertar control pago
-                    for (int i = 0; i < cantMesesPagados; i++)
+                    if(cantMesesPagados != 0)
                     {
-                        guardarControlPago(codPegue, i + 1);
-                    }
+                        for (int i = 0; i < cantMesesPagados; i++)
+                        {
+                            guardarControlPago(codPegue, i + 1);
+                        }
+                    } 
+                    
+                    guardarFechaEstadoPegue(estado, 13, codPegue, "2000");
                     pgbPorcentajeAlmacenado.Value = 75;
                 }
                 else
@@ -212,17 +436,16 @@ namespace ControlAbonados.Forms
                         tipoPegue,
                         estado,
                         bloque,
-                        casa);
+                        casa,
+                        nota);
                     pgbPorcentajeAlmacenado.Value = 25;
 
 
-                    for (int i = 0; i < cantMesesPagados; i++)
-                    {
-                        guardarControlPago(codPegue, i + 1);
-                    }
+                    //guardarControlPago(codPegue, 13);
+                    
                     pgbPorcentajeAlmacenado.Value = 50;
 
-                    guardarFechaEstadoPegue(tipoPegue, mesEstado, codPegue, año);
+                    guardarFechaEstadoPegue(estado, mesEstado, codPegue, año);
                     pgbPorcentajeAlmacenado.Value = 75;
                 }
 
@@ -233,18 +456,27 @@ namespace ControlAbonados.Forms
                 numeroPegueActual++;
                 numBloque.Focus();
                 pgbPorcentajeAlmacenado.Visible = false;
-                pgbPorcentajeAlmacenado.Value = 0;
+                pgbPorcentajeAlmacenado.Value = 0;                
 
                 if(numeroPegueActual == cantidadPegues)
                 {
+                    resetearPegue();
+                    resetearAbonadoEnPegue();
+                    DataAbonadoAccess.cargarTablaListados(dgvListados);
+                    MessageBox.Show($"Pegues de {nombreAbonado} {apellidoAbonado} guardados correctamente.", "Pegues", MessageBoxButtons.OK);
                     numeroPegueActual = 1;
                     regresarASolicitarAbonado();
+                    
                 }
 
             }            
             
         }
 
+        /*
+         * 
+         */
+
         /*
          * funcion para guardar los controles de pago
          */
@@ -384,7 +616,8 @@ namespace ControlAbonados.Forms
             int estadoPegueId,
             // IdBloque
             int bloqueId,
-            string casa
+            string casa,
+            string nota = ""
             )
         {
             Pegue pegue = new Pegue
@@ -394,7 +627,8 @@ namespace ControlAbonados.Forms
                 IdTipoPegue = tipoPegueId,
                 IdEstadoPegue = estadoPegueId,
                 IdBloque = bloqueId,
-                NumCasa = casa
+                NumCasa = casa,
+                Nota = nota
             };
             DataAbonadoAccess.insertarPegue(pegue);
         }
@@ -443,6 +677,18 @@ namespace ControlAbonados.Forms
 
         /* -------------------- Interfaz --------------------*/
 
+        /*
+         * funcion para resetear la info de abonado en el tab de pegues
+         */
+        public void resetearAbonadoEnPegue()
+        {
+            lblIdAbonado.Text = "";
+            lblCantidadPegues.Text = "";
+            txtNombreTab2.Text = "";
+            txtApellidosTab2.Text = "";
+            txtNumeroIdentidadTab2.Text = "";
+        }
+
         /*
          * Funcion para resetear los controles del pegue
          */
@@ -453,8 +699,7 @@ namespace ControlAbonados.Forms
             DataAbonadoAccess.obtenerTipoPegues(cboTipoPegue);
             DataAbonadoAccess.obtenerEstadoPegues(cboEstado);
             DataAbonadoAccess.obtenerMeses(cboMes);
-            lsbMeses.Items.Clear();
-            lblMesesPagados.Text = "Meses pagados";
+            txtNota.Text = "";
         }
 
         /*
@@ -528,7 +773,8 @@ namespace ControlAbonados.Forms
             pnlListados.BackColor = Color.FromArgb(7, 67, 106);
             pnlAbonados.BackColor = Color.FromArgb(7, 67, 106);
             _drawborderAbonado = false;
-            
+            dgvBloqueCasa.Rows.Clear();
+
         }
 
         /*
@@ -553,6 +799,8 @@ namespace ControlAbonados.Forms
             pnlMenu.BackColor = Color.FromArgb(7, 67, 106);
             pnlPegues.BackColor = Color.FromArgb(7, 67, 106);
             pnlAbonados.BackColor = Color.FromArgb(7, 67, 106);
+            DataAbonadoAccess.cargarTablaListados(dgvListados, "Nombre");
+            txtBusqueda.Focus();
         }
 
         /* -------------------- UX -------------------- */
@@ -620,6 +868,7 @@ namespace ControlAbonados.Forms
             DataAbonadoAccess.obtenerTipoPegues(cboTipoPegue);
             DataAbonadoAccess.obtenerMeses(cboMes);
             DataAbonadoAccess.obtenerEstadoPegues(cboEstado);
+            DataAbonadoAccess.obtenerMeses(cboMesEstado);
         }
 
         private void textBox1_TextChanged(object sender, EventArgs e)
@@ -644,7 +893,7 @@ namespace ControlAbonados.Forms
         {
             if (validarAbonados())
             {
-                string numIdentidad = mTxtNumIdentidad.Text;
+                string numIdentidad = (mTxtNumIdentidad.Text == "    -    -")? "" : mTxtNumIdentidad.Text;
                 string nombres = txtNombres.Text;
                 string apellidos = txtApellidos.Text;
 
@@ -654,6 +903,7 @@ namespace ControlAbonados.Forms
                 seleccionarPanelPegues();
                 int idAbonado = guardarAbonado(numIdentidad, nombres, apellidos);
                 lblCantidadPegues.Text = numCantPegues.Value.ToString();
+                lblCantPegues.Text = $"Registrando pegue {numeroPegueActual + 1} de {numCantPegues.Value.ToString()}";
                 lblIdAbonado.Text = idAbonado.ToString();
                 resetearAbonado();
             }
@@ -706,18 +956,69 @@ namespace ControlAbonados.Forms
         private void cboEstado_SelectedIndexChanged(object sender, EventArgs e)
         {
             int indiceCboEstado = cboEstado.SelectedIndex;
+            int cantidadMesesPagados = (lblCantMesesPagados.Text == "Nombres") ? 0 : Convert.ToInt32(lblCantMesesPagados.Text);
+            string[] meses = {
+                "Enero",
+                "Febrero",
+                "Marzo",
+                "Abril",
+                "Mayo",
+                "Junio",
+                "Julio",
+                "Agosto",
+                "Septiembre",
+                "Octubre",
+                "Noviembre",
+                "Diciembre"
+            };
 
-            if(indiceCboEstado > 0)
+            if (indiceCboEstado > 0)
             {
                 lblEstado.Visible = true;
                 habilitarMesYearEstado(true);
                 lblEstado.Text = $"{cboEstado.Text} desde: ";
+                lsbMeses.Items.Clear();
+                cboMes.Enabled = false;
+                lsbMeses.Items.Add("");
+                lsbMeses.Enabled = false;
+                btnAddMes.Visible = false;
+                btnQuitarMes.Visible = false;
                 DataAbonadoAccess.obtenerMeses(cboMesEstado);
             } else
             {
-                lblEstado.Text = "";
-                lblEstado.Visible = false;
-                habilitarMesYearEstado(false);
+                if(Convert.ToInt32(cantidadMesesPagados) > 0)
+                {
+                    DataAbonadoAccess.obtenerMeses(cboMes);
+                    lblEstado.Text = "";
+                    lblEstado.Visible = false;
+                    habilitarMesYearEstado(false);
+                    cboMes.Enabled = true;
+                    cboMes.SelectedIndex = 0;
+                    lsbMeses.Items.Clear();
+                    lsbMeses.Enabled = true;
+                    btnAddMes.Visible = true;
+                    btnQuitarMes.Visible = true;
+                    lblMesesPagados.Text = "Meses pagados";
+                    DataAbonadoAccess.excluirMes(cboMes, cantidadMesesPagados);
+                    for (int i = 0; i < cantidadMesesPagados; i++)
+                    {
+                        lsbMeses.Items.Add(meses[i]);
+                    }
+                } else
+                {
+                    DataAbonadoAccess.obtenerMeses(cboMes);
+                    lblEstado.Text = "";
+                    lblEstado.Visible = false;
+                    habilitarMesYearEstado(false);
+                    cboMes.Enabled = true;
+                    cboMes.SelectedIndex = 0;
+                    lsbMeses.Items.Clear();
+                    lsbMeses.Enabled = true;
+                    btnAddMes.Visible = true;
+                    btnQuitarMes.Visible = true;
+                    lblMesesPagados.Text = "Meses pagados";
+                }
+
             }
 
         }
@@ -734,18 +1035,13 @@ namespace ControlAbonados.Forms
 
         private void cboTipoBusqueda_SelectedIndexChanged(object sender, EventArgs e)
         {
-            if(cboTipoBusqueda.SelectedIndex == 0)
-            {
-                lblCancelarFiltro.Visible = false;
-                DataAbonadoAccess.cargarTablaListados(dgvListados);
-                habilitarControlesBusqueda(false);
-            } else if(cboTipoBusqueda.SelectedIndex == 4)
+            if(cboTipoBusqueda.SelectedIndex == 3)
             {
                 lblCancelarFiltro.Visible = true;
                 habilitarCboBusqueda(true, cboTipoBusqueda.Text);
                 txtBusqueda.Text = "";
                 txtBusqueda.Focus();
-            } else if (cboTipoBusqueda.SelectedIndex == 5)
+            } else if (cboTipoBusqueda.SelectedIndex == 4)
             {
                 lblCancelarFiltro.Visible = true;
                 habilitarCboBusqueda(true, cboTipoBusqueda.Text);
@@ -768,9 +1064,82 @@ namespace ControlAbonados.Forms
         private void lblCancelarFiltro_Click(object sender, EventArgs e)
         {
             cboTipoBusqueda.SelectedIndex = 0;
-            DataAbonadoAccess.cargarTablaListados(dgvListados);
-            habilitarControlesBusqueda(false);
+            DataAbonadoAccess.cargarTablaListados(dgvListados, "Nombre");
             lblCancelarFiltro.Visible = false;
         }
+
+        private void btnEditarAbonado_Click(object sender, EventArgs e)
+        {
+
+            
+            moverAbonadosAEdicion();
+        }
+
+        private void button1_Click(object sender, EventArgs e)
+        {
+            if (validarAbonados())
+            {
+                DialogResult r = MessageBox.Show("¿Desea cancelar la edición? \nLa información no será guardada", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
+                if (r == DialogResult.Yes)
+                {
+                    resetearAbonado();
+                    if (btnGuardarAbonadoEditado.Visible)
+                    {
+                        btnGuardarAbonadoEditado.Visible = false;
+                        btnGuardarAbonado.Enabled = true;
+                        btnGuardarAbonado.Visible = true;
+                    }
+                    abrirMenu();
+                }
+            } else
+            {
+                abrirMenu();
+            }        
+                        
+        }
+
+
+        private void btnGuardarAbonadoEditado_Click(object sender, EventArgs e)
+        {
+            try
+            {
+                guardarAbonadoEditado();
+                resetearAbonado();
+
+                btnGuardarAbonadoEditado.Enabled = false;
+                btnGuardarAbonadoEditado.Visible = false;
+
+                btnGuardarAbonado.Enabled = true;
+                btnGuardarAbonado.Visible = true;
+
+                numCantPegues.Enabled = true;
+            } catch(Exception ex)
+            {
+                MessageBox.Show($"Al parecer ocurrio un error, intentelo más tarde.\n {ex.Message}");
+            }
+        }
+
+        private void btnEditarPegue_Click(object sender, EventArgs e)
+        {
+            moverPegueAEdicion();
+        }
+
+        private void btnGuardarPegue_Click(object sender, EventArgs e)
+        {
+            
+                if (validarPegue())
+                {
+                    guardaPegueEditado();
+                    resetearPegue();
+
+                    btnGuardarPegue.Enabled = false;
+                    btnGuardarPegue.Visible = false;
+
+                    btnSiguientePegue.Enabled = true;
+                    btnSiguientePegue.Visible = true;
+                }
+            
+
+        }
     }
 }
diff --git a/Visual proyect/ControlAbonados/ControlAbonados/Forms/Abonados.resx b/Visual proyect/ControlAbonados/ControlAbonados/Forms/Abonados.resx
index 6b376d5..489526a 100644
--- a/Visual proyect/ControlAbonados/ControlAbonados/Forms/Abonados.resx	
+++ b/Visual proyect/ControlAbonados/ControlAbonados/Forms/Abonados.resx	
@@ -123,35 +123,35 @@
   <metadata name="bunifuTransition1.TrayLocation" type="System.Drawing.Point, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a">
     <value>17, 17</value>
   </metadata>
-  <data name="animation3.BlindCoeff" mimetype="application/x-microsoft.net.object.binary.base64">
+  <data name="animation2.BlindCoeff" mimetype="application/x-microsoft.net.object.binary.base64">
     <value>
         AAEAAAD/////AQAAAAAAAAAMAgAAAFFTeXN0ZW0uRHJhd2luZywgVmVyc2lvbj00LjAuMC4wLCBDdWx0
         dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWIwM2Y1ZjdmMTFkNTBhM2EFAQAAABVTeXN0ZW0uRHJh
         d2luZy5Qb2ludEYCAAAAAXgBeQAACwsCAAAAAAAAAAAAAAAL
 </value>
   </data>
-  <data name="animation3.MosaicCoeff" mimetype="application/x-microsoft.net.object.binary.base64">
+  <data name="animation2.MosaicCoeff" mimetype="application/x-microsoft.net.object.binary.base64">
     <value>
         AAEAAAD/////AQAAAAAAAAAMAgAAAFFTeXN0ZW0uRHJhd2luZywgVmVyc2lvbj00LjAuMC4wLCBDdWx0
         dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWIwM2Y1ZjdmMTFkNTBhM2EFAQAAABVTeXN0ZW0uRHJh
         d2luZy5Qb2ludEYCAAAAAXgBeQAACwsCAAAAAAAAAAAAAAAL
 </value>
   </data>
-  <data name="animation3.MosaicShift" mimetype="application/x-microsoft.net.object.binary.base64">
+  <data name="animation2.MosaicShift" mimetype="application/x-microsoft.net.object.binary.base64">
     <value>
         AAEAAAD/////AQAAAAAAAAAMAgAAAFFTeXN0ZW0uRHJhd2luZywgVmVyc2lvbj00LjAuMC4wLCBDdWx0
         dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWIwM2Y1ZjdmMTFkNTBhM2EFAQAAABVTeXN0ZW0uRHJh
         d2luZy5Qb2ludEYCAAAAAXgBeQAACwsCAAAAAAAAAAAAAAAL
 </value>
   </data>
-  <data name="animation3.ScaleCoeff" mimetype="application/x-microsoft.net.object.binary.base64">
+  <data name="animation2.ScaleCoeff" mimetype="application/x-microsoft.net.object.binary.base64">
     <value>
         AAEAAAD/////AQAAAAAAAAAMAgAAAFFTeXN0ZW0uRHJhd2luZywgVmVyc2lvbj00LjAuMC4wLCBDdWx0
         dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWIwM2Y1ZjdmMTFkNTBhM2EFAQAAABVTeXN0ZW0uRHJh
         d2luZy5Qb2ludEYCAAAAAXgBeQAACwsCAAAAAAAAAAAAAAAL
 </value>
   </data>
-  <data name="animation3.SlideCoeff" mimetype="application/x-microsoft.net.object.binary.base64">
+  <data name="animation2.SlideCoeff" mimetype="application/x-microsoft.net.object.binary.base64">
     <value>
         AAEAAAD/////AQAAAAAAAAAMAgAAAFFTeXN0ZW0uRHJhd2luZywgVmVyc2lvbj00LjAuMC4wLCBDdWx0
         dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWIwM2Y1ZjdmMTFkNTBhM2EFAQAAABVTeXN0ZW0uRHJh
diff --git a/Visual proyect/ControlAbonados/ControlAbonados/Forms/ReportesMenu.Designer.cs b/Visual proyect/ControlAbonados/ControlAbonados/Forms/ReportesMenu.Designer.cs
index 4926de6..38c9fd8 100644
--- a/Visual proyect/ControlAbonados/ControlAbonados/Forms/ReportesMenu.Designer.cs	
+++ b/Visual proyect/ControlAbonados/ControlAbonados/Forms/ReportesMenu.Designer.cs	
@@ -39,21 +39,21 @@ namespace ControlAbonados.Forms
             this.label2 = new System.Windows.Forms.Label();
             this.label3 = new System.Windows.Forms.Label();
             this.panel2 = new System.Windows.Forms.Panel();
+            this.cboMes = new System.Windows.Forms.ComboBox();
             this.button2 = new System.Windows.Forms.Button();
             this.label4 = new System.Windows.Forms.Label();
             this.label5 = new System.Windows.Forms.Label();
-            this.pictureBox1 = new System.Windows.Forms.PictureBox();
             this.panel3 = new System.Windows.Forms.Panel();
+            this.cboEstado = new System.Windows.Forms.ComboBox();
             this.button3 = new System.Windows.Forms.Button();
             this.label6 = new System.Windows.Forms.Label();
             this.label7 = new System.Windows.Forms.Label();
-            this.cboMes = new System.Windows.Forms.ComboBox();
-            this.cboEstado = new System.Windows.Forms.ComboBox();
+            this.pictureBox1 = new System.Windows.Forms.PictureBox();
             this.pnlAbonados.SuspendLayout();
             this.panel1.SuspendLayout();
             this.panel2.SuspendLayout();
-            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
             this.panel3.SuspendLayout();
+            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
             this.SuspendLayout();
             // 
             // pnlAbonados
@@ -82,6 +82,7 @@ namespace ControlAbonados.Forms
             this.btnAbonado.TabIndex = 2;
             this.btnAbonado.Text = "Generar";
             this.btnAbonado.UseVisualStyleBackColor = false;
+            this.btnAbonado.Click += new System.EventHandler(this.btnAbonado_Click);
             // 
             // label1
             // 
@@ -176,6 +177,18 @@ namespace ControlAbonados.Forms
             this.panel2.Size = new System.Drawing.Size(300, 200);
             this.panel2.TabIndex = 7;
             // 
+            // cboMes
+            // 
+            this.cboMes.BackColor = System.Drawing.Color.White;
+            this.cboMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
+            this.cboMes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
+            this.cboMes.Font = new System.Drawing.Font("Product Sans", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
+            this.cboMes.FormattingEnabled = true;
+            this.cboMes.Location = new System.Drawing.Point(26, 90);
+            this.cboMes.Name = "cboMes";
+            this.cboMes.Size = new System.Drawing.Size(254, 29);
+            this.cboMes.TabIndex = 9;
+            // 
             // button2
             // 
             this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
@@ -213,17 +226,6 @@ namespace ControlAbonados.Forms
             this.label5.TabIndex = 0;
             this.label5.Text = "Reporte mes";
             // 
-            // pictureBox1
-            // 
-            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
-            this.pictureBox1.Image = global::ControlAbonados.Properties.Resources.home_negro_512;
-            this.pictureBox1.Location = new System.Drawing.Point(1210, 26);
-            this.pictureBox1.Name = "pictureBox1";
-            this.pictureBox1.Size = new System.Drawing.Size(40, 40);
-            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
-            this.pictureBox1.TabIndex = 8;
-            this.pictureBox1.TabStop = false;
-            // 
             // panel3
             // 
             this.panel3.BackColor = System.Drawing.Color.White;
@@ -237,6 +239,18 @@ namespace ControlAbonados.Forms
             this.panel3.Size = new System.Drawing.Size(300, 200);
             this.panel3.TabIndex = 8;
             // 
+            // cboEstado
+            // 
+            this.cboEstado.BackColor = System.Drawing.Color.White;
+            this.cboEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
+            this.cboEstado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
+            this.cboEstado.Font = new System.Drawing.Font("Product Sans", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
+            this.cboEstado.FormattingEnabled = true;
+            this.cboEstado.Location = new System.Drawing.Point(23, 86);
+            this.cboEstado.Name = "cboEstado";
+            this.cboEstado.Size = new System.Drawing.Size(254, 29);
+            this.cboEstado.TabIndex = 10;
+            // 
             // button3
             // 
             this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
@@ -274,29 +288,16 @@ namespace ControlAbonados.Forms
             this.label7.TabIndex = 0;
             this.label7.Text = "Reporte estado";
             // 
-            // cboMes
-            // 
-            this.cboMes.BackColor = System.Drawing.Color.White;
-            this.cboMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
-            this.cboMes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
-            this.cboMes.Font = new System.Drawing.Font("Product Sans", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
-            this.cboMes.FormattingEnabled = true;
-            this.cboMes.Location = new System.Drawing.Point(26, 90);
-            this.cboMes.Name = "cboMes";
-            this.cboMes.Size = new System.Drawing.Size(254, 29);
-            this.cboMes.TabIndex = 9;
-            // 
-            // cboEstado
+            // pictureBox1
             // 
-            this.cboEstado.BackColor = System.Drawing.Color.White;
-            this.cboEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
-            this.cboEstado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
-            this.cboEstado.Font = new System.Drawing.Font("Product Sans", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
-            this.cboEstado.FormattingEnabled = true;
-            this.cboEstado.Location = new System.Drawing.Point(23, 86);
-            this.cboEstado.Name = "cboEstado";
-            this.cboEstado.Size = new System.Drawing.Size(254, 29);
-            this.cboEstado.TabIndex = 10;
+            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
+            this.pictureBox1.Image = global::ControlAbonados.Properties.Resources.home_negro_512;
+            this.pictureBox1.Location = new System.Drawing.Point(1210, 26);
+            this.pictureBox1.Name = "pictureBox1";
+            this.pictureBox1.Size = new System.Drawing.Size(40, 40);
+            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
+            this.pictureBox1.TabIndex = 8;
+            this.pictureBox1.TabStop = false;
             // 
             // ReportesMenu
             // 
@@ -319,9 +320,9 @@ namespace ControlAbonados.Forms
             this.panel1.PerformLayout();
             this.panel2.ResumeLayout(false);
             this.panel2.PerformLayout();
-            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
             this.panel3.ResumeLayout(false);
             this.panel3.PerformLayout();
+            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
             this.ResumeLayout(false);
             this.PerformLayout();
 
diff --git a/Visual proyect/ControlAbonados/ControlAbonados/Forms/ReportesMenu.cs b/Visual proyect/ControlAbonados/ControlAbonados/Forms/ReportesMenu.cs
index 7984e6d..80bbe45 100644
--- a/Visual proyect/ControlAbonados/ControlAbonados/Forms/ReportesMenu.cs	
+++ b/Visual proyect/ControlAbonados/ControlAbonados/Forms/ReportesMenu.cs	
@@ -2,12 +2,19 @@
 using System.Collections.Generic;
 using System.ComponentModel;
 using System.Data;
+using System.Diagnostics;
 using System.Drawing;
+using System.IO;
 using System.Linq;
 using System.Text;
 using System.Threading.Tasks;
 using System.Windows.Forms;
 using ControlAbonados.Data;
+using CrystalDecisions.CrystalReports.Engine;
+using CrystalDecisions.CrystalReports.ViewerObjectModel;
+using CrystalDecisions.Windows.Forms;
+using CrystalDecisions.Shared;
+using ControlAbonados.Reportes;
 
 namespace ControlAbonados.Forms
 {
@@ -23,5 +30,61 @@ namespace ControlAbonados.Forms
             DataAbonadoAccess.obtenerMeses(cboMes);
             DataAbonadoAccess.obtenerEstadoPegues(cboEstado);
         }
+
+        public void crearOAbrirFolderReportes()
+        {
+            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
+            string folderEspecifico = $"{desktopPath}\\Reportes";
+            Process.Start("explorer.exe", folderEspecifico);
+            /*try
+            {
+                if (Directory.Exists(folderEspecifico))
+                {
+                    Process.Start("explorer.exe", $"@{folderEspecifico}");
+                }
+                else
+                {
+                    Directory.CreateDirectory(folderEspecifico);
+                    Process.Start("explorer.exe", folderEspecifico);
+                }
+            }
+            catch (Exception e)
+            {
+                Process.Start("explorer.exe", desktopPath);
+                Console.Write(e.Message);
+            }*/
+
+        }
+
+        public void generarReporteTodoAbonados()
+        {
+            string directorioReporte = $"{Directory.GetCurrentDirectory()}\\listadoTodoAbonados.rpt";
+            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
+            string folderEspecifico = $@"{desktopPath}\\Reportes\\ReporteTodoAbonado.pdf";
+
+            using (ReportDocument oRep = new ReportDocument())
+            {
+                using (frmListadoTodoAbonados form = new frmListadoTodoAbonados())
+                {
+                    oRep.Load(@"C:\Users\Manrique\Desktop\PROYECTO CONTROL ABONADO\ControlAbonadoApp\Visual proyect\ControlAbonados\ControlAbonados\Reportes\ListadoTodoAbonados.rpt");
+                    form.crystalReportViewer1.ReportSource = oRep;
+                    form.Show();
+                    oRep.ExportToDisk(ExportFormatType.PortableDocFormat, folderEspecifico);
+                    form.Close();
+                }
+            }
+            crearOAbrirFolderReportes();
+        }
+
+        private void generarReportesAbonado()
+        {
+
+        }
+
+        private void btnAbonado_Click(object sender, EventArgs e)
+        {
+            generarReporteTodoAbonados();
+            //string directorioReporte = $"@{Directory.GetCurrentDirectory()}\\listadoTodoAbonados.rpt";
+        }
     }
 }
diff --git a/Visual proyect/ControlAbonados/ControlAbonados/Models/Abonado.cs b/Visual proyect/ControlAbonados/ControlAbonados/Models/Abonado.cs
index 13e181d..c31f189 100644
--- a/Visual proyect/ControlAbonados/ControlAbonados/Models/Abonado.cs	
+++ b/Visual proyect/ControlAbonados/ControlAbonados/Models/Abonado.cs	
@@ -13,7 +13,6 @@ namespace ControlAbonados.Models
         [Key]
         public int IdAbonado { get; set; }
 
-        [Index(IsUnique=true)]
         [MaxLength(15)]
         public string NumIdentidad { get; set; }
 
diff --git a/Visual proyect/ControlAbonados/ControlAbonados/Models/Pegue.cs b/Visual proyect/ControlAbonados/ControlAbonados/Models/Pegue.cs
index 69b150f..9a2c15b 100644
--- a/Visual proyect/ControlAbonados/ControlAbonados/Models/Pegue.cs	
+++ b/Visual proyect/ControlAbonados/ControlAbonados/Models/Pegue.cs	
@@ -33,5 +33,8 @@ namespace ControlAbonados.Models
         [MaxLength(3)]
         public string NumCasa { get; set; } 
 
+        [DataType(DataType.MultilineText)]
+        public string Nota { get; set; }
+
     }
 }
diff --git a/Visual proyect/ControlAbonados/ControlAbonados/Program.cs b/Visual proyect/ControlAbonados/ControlAbonados/Program.cs
index 0429995..122d11c 100644
--- a/Visual proyect/ControlAbonados/ControlAbonados/Program.cs	
+++ b/Visual proyect/ControlAbonados/ControlAbonados/Program.cs	
@@ -17,7 +17,7 @@ namespace ControlAbonados
         {
             Application.EnableVisualStyles();
             Application.SetCompatibleTextRenderingDefault(false);
-            Application.Run(new ReportesMenu());
+            Application.Run(new Abonados());
         }
     }
 }
diff --git a/Visual proyect/ControlAbonados/ControlAbonados/bin/Debug/ControlAbonados.exe b/Visual proyect/ControlAbonados/ControlAbonados/bin/Debug/ControlAbonados.exe
index fb40d99..39e4be8 100644
Binary files a/Visual proyect/ControlAbonados/ControlAbonados/bin/Debug/ControlAbonados.exe and b/Visual proyect/ControlAbonados/ControlAbonados/bin/Debug/ControlAbonados.exe differ
diff --git a/Visual proyect/ControlAbonados/ControlAbonados/bin/Debug/ControlAbonados.pdb b/Visual proyect/ControlAbonados/ControlAbonados/bin/Debug/ControlAbonados.pdb
index f687e6b..549adfb 100644
Binary files a/Visual proyect/ControlAbonados/ControlAbonados/bin/Debug/ControlAbonados.pdb and b/Visual proyect/ControlAbonados/ControlAbonados/bin/Debug/ControlAbonados.pdb differ
diff --git a/Visual proyect/ControlAbonados/ControlAbonados/obj/Debug/ControlAbonados.Forms.Abonados.resources b/Visual proyect/ControlAbonados/ControlAbonados/obj/Debug/ControlAbonados.Forms.Abonados.resources
index d918975..483182c 100644
Binary files a/Visual proyect/ControlAbonados/ControlAbonados/obj/Debug/ControlAbonados.Forms.Abonados.resources and b/Visual proyect/ControlAbonados/ControlAbonados/obj/Debug/ControlAbonados.Forms.Abonados.resources differ
diff --git a/Visual proyect/ControlAbonados/ControlAbonados/obj/Debug/ControlAbonados.csproj.CoreCompileInputs.cache b/Visual proyect/ControlAbonados/ControlAbonados/obj/Debug/ControlAbonados.csproj.CoreCompileInputs.cache
index a6c3ef6..9347198 100644
--- a/Visual proyect/ControlAbonados/ControlAbonados/obj/Debug/ControlAbonados.csproj.CoreCompileInputs.cache	
+++ b/Visual proyect/ControlAbonados/ControlAbonados/obj/Debug/ControlAbonados.csproj.CoreCompileInputs.cache	
@@ -1 +1 @@
-4a3ba092edae0d310470e313788bf342459f8a0e
+77fcea4acd2b1958fa37944aedbd90ddeed9a213
diff --git a/Visual proyect/ControlAbonados/ControlAbonados/obj/Debug/ControlAbonados.csproj.FileListAbsolute.txt b/Visual proyect/ControlAbonados/ControlAbonados/obj/Debug/ControlAbonados.csproj.FileListAbsolute.txt
index 0ec81c0..04e2dbc 100644
--- a/Visual proyect/ControlAbonados/ControlAbonados/obj/Debug/ControlAbonados.csproj.FileListAbsolute.txt	
+++ b/Visual proyect/ControlAbonados/ControlAbonados/obj/Debug/ControlAbonados.csproj.FileListAbsolute.txt	
@@ -57,3 +57,6 @@ C:\Users\Manrique\Desktop\PROYECTO CONTROL ABONADO\ControlAbonadoApp\Visual proy
 C:\Users\Manrique\Desktop\PROYECTO CONTROL ABONADO\ControlAbonadoApp\Visual proyect\ControlAbonados\ControlAbonados\obj\Debug\ControlAbonados.Migrations.EliminarAñoFromDBMigration.resources
 C:\Users\Manrique\Desktop\PROYECTO CONTROL ABONADO\ControlAbonadoApp\Visual proyect\ControlAbonados\ControlAbonados\obj\Debug\ControlAbonados.Migrations.ColumnaAñoMigration.resources
 C:\Users\Manrique\Desktop\PROYECTO CONTROL ABONADO\ControlAbonadoApp\Visual proyect\ControlAbonados\ControlAbonados\obj\Debug\ControlAbonados.Migrations.CodPegueFechaEstadoPegueMigration.resources
+C:\Users\Manrique\Desktop\PROYECTO CONTROL ABONADO\ControlAbonadoApp\Visual proyect\ControlAbonados\ControlAbonados\obj\Debug\ControlAbonados.Reportes.frmListadoTodoAbonados.resources
+C:\Users\Manrique\Desktop\PROYECTO CONTROL ABONADO\ControlAbonadoApp\Visual proyect\ControlAbonados\ControlAbonados\obj\Debug\ControlAbonados.Migrations.NumeroIdentidadNoEsUniqueMigration.resources
+C:\Users\Manrique\Desktop\PROYECTO CONTROL ABONADO\ControlAbonadoApp\Visual proyect\ControlAbonados\ControlAbonados\obj\Debug\ControlAbonados.Migrations.NotasPegueMigration.resources
diff --git a/Visual proyect/ControlAbonados/ControlAbonados/obj/Debug/ControlAbonados.csproj.GenerateResource.cache b/Visual proyect/ControlAbonados/ControlAbonados/obj/Debug/ControlAbonados.csproj.GenerateResource.cache
index b5f8b26..509fb19 100644
Binary files a/Visual proyect/ControlAbonados/ControlAbonados/obj/Debug/ControlAbonados.csproj.GenerateResource.cache and b/Visual proyect/ControlAbonados/ControlAbonados/obj/Debug/ControlAbonados.csproj.GenerateResource.cache differ
diff --git a/Visual proyect/ControlAbonados/ControlAbonados/obj/Debug/ControlAbonados.csprojAssemblyReference.cache b/Visual proyect/ControlAbonados/ControlAbonados/obj/Debug/ControlAbonados.csprojAssemblyReference.cache
index 492768e..eefded9 100644
Binary files a/Visual proyect/ControlAbonados/ControlAbonados/obj/Debug/ControlAbonados.csprojAssemblyReference.cache and b/Visual proyect/ControlAbonados/ControlAbonados/obj/Debug/ControlAbonados.csprojAssemblyReference.cache differ
diff --git a/Visual proyect/ControlAbonados/ControlAbonados/obj/Debug/ControlAbonados.exe b/Visual proyect/ControlAbonados/ControlAbonados/obj/Debug/ControlAbonados.exe
index fb40d99..39e4be8 100644
Binary files a/Visual proyect/ControlAbonados/ControlAbonados/obj/Debug/ControlAbonados.exe and b/Visual proyect/ControlAbonados/ControlAbonados/obj/Debug/ControlAbonados.exe differ
diff --git a/Visual proyect/ControlAbonados/ControlAbonados/obj/Debug/ControlAbonados.pdb b/Visual proyect/ControlAbonados/ControlAbonados/obj/Debug/ControlAbonados.pdb
index f687e6b..549adfb 100644
Binary files a/Visual proyect/ControlAbonados/ControlAbonados/obj/Debug/ControlAbonados.pdb and b/Visual proyect/ControlAbonados/ControlAbonados/obj/Debug/ControlAbonados.pdb differ
diff --git a/Visual proyect/ControlAbonados/ControlAbonados/obj/Debug/DesignTimeResolveAssemblyReferences.cache b/Visual proyect/ControlAbonados/ControlAbonados/obj/Debug/DesignTimeResolveAssemblyReferences.cache
index ce31de4..72efbcf 100644
Binary files a/Visual proyect/ControlAbonados/ControlAbonados/obj/Debug/DesignTimeResolveAssemblyReferences.cache and b/Visual proyect/ControlAbonados/ControlAbonados/obj/Debug/DesignTimeResolveAssemblyReferences.cache differ
diff --git a/Visual proyect/ControlAbonados/ControlAbonados/obj/Debug/DesignTimeResolveAssemblyReferencesInput.cache b/Visual proyect/ControlAbonados/ControlAbonados/obj/Debug/DesignTimeResolveAssemblyReferencesInput.cache
index cc72fcd..fb79fd3 100644
Binary files a/Visual proyect/ControlAbonados/ControlAbonados/obj/Debug/DesignTimeResolveAssemblyReferencesInput.cache and b/Visual proyect/ControlAbonados/ControlAbonados/obj/Debug/DesignTimeResolveAssemblyReferencesInput.cache differ
