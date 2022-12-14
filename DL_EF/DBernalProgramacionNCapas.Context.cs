//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DL_EF
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class DBernalProgramacionNCapasEntities : DbContext
    {
        public DBernalProgramacionNCapasEntities()
            : base("name=DBernalProgramacionNCapasEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Aseguradora> Aseguradoras { get; set; }
        public virtual DbSet<Colonia> Colonias { get; set; }
        public virtual DbSet<Dependiente> Dependientes { get; set; }
        public virtual DbSet<DependienteTipo> DependienteTipoes { get; set; }
        public virtual DbSet<Direccion> Direccions { get; set; }
        public virtual DbSet<Empleado> Empleadoes { get; set; }
        public virtual DbSet<Empresa> Empresas { get; set; }
        public virtual DbSet<Estado> Estadoes { get; set; }
        public virtual DbSet<EstadoCivil> EstadoCivils { get; set; }
        public virtual DbSet<Municipio> Municipios { get; set; }
        public virtual DbSet<Pai> Pais { get; set; }
        public virtual DbSet<Rol> Rols { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
    
        public virtual int AseguradoraAdd(string nombre, Nullable<int> idUsuario, ObjectParameter mensaje, ObjectParameter idAseguradora)
        {
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var idUsuarioParameter = idUsuario.HasValue ?
                new ObjectParameter("IdUsuario", idUsuario) :
                new ObjectParameter("IdUsuario", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AseguradoraAdd", nombreParameter, idUsuarioParameter, mensaje, idAseguradora);
        }
    
        public virtual int AseguradoraDelete(Nullable<int> idAseguradora, ObjectParameter mensaje)
        {
            var idAseguradoraParameter = idAseguradora.HasValue ?
                new ObjectParameter("IdAseguradora", idAseguradora) :
                new ObjectParameter("IdAseguradora", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AseguradoraDelete", idAseguradoraParameter, mensaje);
        }
    
        public virtual ObjectResult<AseguradoraGet_Result> AseguradoraGet(Nullable<int> idAseguradora)
        {
            var idAseguradoraParameter = idAseguradora.HasValue ?
                new ObjectParameter("IdAseguradora", idAseguradora) :
                new ObjectParameter("IdAseguradora", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<AseguradoraGet_Result>("AseguradoraGet", idAseguradoraParameter);
        }
    
        public virtual int AseguradoraUpdate(string nombre, Nullable<int> idUsuario, Nullable<int> idAseguradora, ObjectParameter mensaje)
        {
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var idUsuarioParameter = idUsuario.HasValue ?
                new ObjectParameter("IdUsuario", idUsuario) :
                new ObjectParameter("IdUsuario", typeof(int));
    
            var idAseguradoraParameter = idAseguradora.HasValue ?
                new ObjectParameter("IdAseguradora", idAseguradora) :
                new ObjectParameter("IdAseguradora", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AseguradoraUpdate", nombreParameter, idUsuarioParameter, idAseguradoraParameter, mensaje);
        }
    
        public virtual ObjectResult<ColoniaGetByIdMunicipio_Result> ColoniaGetByIdMunicipio(Nullable<int> idMunicipio)
        {
            var idMunicipioParameter = idMunicipio.HasValue ?
                new ObjectParameter("IdMunicipio", idMunicipio) :
                new ObjectParameter("IdMunicipio", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ColoniaGetByIdMunicipio_Result>("ColoniaGetByIdMunicipio", idMunicipioParameter);
        }
    
        public virtual int DependienteAdd(string numeroEmpleado, string nombre, string apellidoPaterno, string apellidoMaterno, string fechaNacimiento, Nullable<int> estadoCivil, string genero, string telefono, string rFC, Nullable<int> idDependienteTipo, ObjectParameter mensaje, ObjectParameter idDependiente)
        {
            var numeroEmpleadoParameter = numeroEmpleado != null ?
                new ObjectParameter("NumeroEmpleado", numeroEmpleado) :
                new ObjectParameter("NumeroEmpleado", typeof(string));
    
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var apellidoPaternoParameter = apellidoPaterno != null ?
                new ObjectParameter("ApellidoPaterno", apellidoPaterno) :
                new ObjectParameter("ApellidoPaterno", typeof(string));
    
            var apellidoMaternoParameter = apellidoMaterno != null ?
                new ObjectParameter("ApellidoMaterno", apellidoMaterno) :
                new ObjectParameter("ApellidoMaterno", typeof(string));
    
            var fechaNacimientoParameter = fechaNacimiento != null ?
                new ObjectParameter("FechaNacimiento", fechaNacimiento) :
                new ObjectParameter("FechaNacimiento", typeof(string));
    
            var estadoCivilParameter = estadoCivil.HasValue ?
                new ObjectParameter("EstadoCivil", estadoCivil) :
                new ObjectParameter("EstadoCivil", typeof(int));
    
            var generoParameter = genero != null ?
                new ObjectParameter("Genero", genero) :
                new ObjectParameter("Genero", typeof(string));
    
            var telefonoParameter = telefono != null ?
                new ObjectParameter("Telefono", telefono) :
                new ObjectParameter("Telefono", typeof(string));
    
            var rFCParameter = rFC != null ?
                new ObjectParameter("RFC", rFC) :
                new ObjectParameter("RFC", typeof(string));
    
            var idDependienteTipoParameter = idDependienteTipo.HasValue ?
                new ObjectParameter("IdDependienteTipo", idDependienteTipo) :
                new ObjectParameter("IdDependienteTipo", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DependienteAdd", numeroEmpleadoParameter, nombreParameter, apellidoPaternoParameter, apellidoMaternoParameter, fechaNacimientoParameter, estadoCivilParameter, generoParameter, telefonoParameter, rFCParameter, idDependienteTipoParameter, mensaje, idDependiente);
        }
    
        public virtual int DependienteDelete(Nullable<int> idDependiente, ObjectParameter mensaje)
        {
            var idDependienteParameter = idDependiente.HasValue ?
                new ObjectParameter("IdDependiente", idDependiente) :
                new ObjectParameter("IdDependiente", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DependienteDelete", idDependienteParameter, mensaje);
        }
    
        public virtual ObjectResult<DependienteGet_Result> DependienteGet(Nullable<int> idDependiente)
        {
            var idDependienteParameter = idDependiente.HasValue ?
                new ObjectParameter("IdDependiente", idDependiente) :
                new ObjectParameter("IdDependiente", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<DependienteGet_Result>("DependienteGet", idDependienteParameter);
        }
    
        public virtual ObjectResult<DependienteGetByIdNumeroEmpleado_Result> DependienteGetByIdNumeroEmpleado(string numeroEmpleado)
        {
            var numeroEmpleadoParameter = numeroEmpleado != null ?
                new ObjectParameter("NumeroEmpleado", numeroEmpleado) :
                new ObjectParameter("NumeroEmpleado", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<DependienteGetByIdNumeroEmpleado_Result>("DependienteGetByIdNumeroEmpleado", numeroEmpleadoParameter);
        }
    
        public virtual ObjectResult<DependienteTipoGet_Result> DependienteTipoGet(Nullable<int> idDependienteTipo)
        {
            var idDependienteTipoParameter = idDependienteTipo.HasValue ?
                new ObjectParameter("IdDependienteTipo", idDependienteTipo) :
                new ObjectParameter("IdDependienteTipo", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<DependienteTipoGet_Result>("DependienteTipoGet", idDependienteTipoParameter);
        }
    
        public virtual int DependienteUpdate(Nullable<int> idDependiente, string numeroEmpleado, string nombre, string apellidoPaterno, string apellidoMaterno, string fechaNacimiento, Nullable<int> estadoCivil, string genero, string telefono, string rFC, Nullable<int> idDependienteTipo, ObjectParameter mensaje)
        {
            var idDependienteParameter = idDependiente.HasValue ?
                new ObjectParameter("IdDependiente", idDependiente) :
                new ObjectParameter("IdDependiente", typeof(int));
    
            var numeroEmpleadoParameter = numeroEmpleado != null ?
                new ObjectParameter("NumeroEmpleado", numeroEmpleado) :
                new ObjectParameter("NumeroEmpleado", typeof(string));
    
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var apellidoPaternoParameter = apellidoPaterno != null ?
                new ObjectParameter("ApellidoPaterno", apellidoPaterno) :
                new ObjectParameter("ApellidoPaterno", typeof(string));
    
            var apellidoMaternoParameter = apellidoMaterno != null ?
                new ObjectParameter("ApellidoMaterno", apellidoMaterno) :
                new ObjectParameter("ApellidoMaterno", typeof(string));
    
            var fechaNacimientoParameter = fechaNacimiento != null ?
                new ObjectParameter("FechaNacimiento", fechaNacimiento) :
                new ObjectParameter("FechaNacimiento", typeof(string));
    
            var estadoCivilParameter = estadoCivil.HasValue ?
                new ObjectParameter("EstadoCivil", estadoCivil) :
                new ObjectParameter("EstadoCivil", typeof(int));
    
            var generoParameter = genero != null ?
                new ObjectParameter("Genero", genero) :
                new ObjectParameter("Genero", typeof(string));
    
            var telefonoParameter = telefono != null ?
                new ObjectParameter("Telefono", telefono) :
                new ObjectParameter("Telefono", typeof(string));
    
            var rFCParameter = rFC != null ?
                new ObjectParameter("RFC", rFC) :
                new ObjectParameter("RFC", typeof(string));
    
            var idDependienteTipoParameter = idDependienteTipo.HasValue ?
                new ObjectParameter("IdDependienteTipo", idDependienteTipo) :
                new ObjectParameter("IdDependienteTipo", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DependienteUpdate", idDependienteParameter, numeroEmpleadoParameter, nombreParameter, apellidoPaternoParameter, apellidoMaternoParameter, fechaNacimientoParameter, estadoCivilParameter, generoParameter, telefonoParameter, rFCParameter, idDependienteTipoParameter, mensaje);
        }
    
        public virtual int EmpleadoAdd(string numeroEmpleado, string rCF, string nombre, string apellidoPaterno, string apellidoMaterno, string email, string telefono, string fechaNacimiento, string nSS, string fechaIngreso, string foto, Nullable<int> idEmpresa, ObjectParameter mensaje, ObjectParameter idEmpleado)
        {
            var numeroEmpleadoParameter = numeroEmpleado != null ?
                new ObjectParameter("NumeroEmpleado", numeroEmpleado) :
                new ObjectParameter("NumeroEmpleado", typeof(string));
    
            var rCFParameter = rCF != null ?
                new ObjectParameter("RCF", rCF) :
                new ObjectParameter("RCF", typeof(string));
    
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var apellidoPaternoParameter = apellidoPaterno != null ?
                new ObjectParameter("ApellidoPaterno", apellidoPaterno) :
                new ObjectParameter("ApellidoPaterno", typeof(string));
    
            var apellidoMaternoParameter = apellidoMaterno != null ?
                new ObjectParameter("ApellidoMaterno", apellidoMaterno) :
                new ObjectParameter("ApellidoMaterno", typeof(string));
    
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            var telefonoParameter = telefono != null ?
                new ObjectParameter("Telefono", telefono) :
                new ObjectParameter("Telefono", typeof(string));
    
            var fechaNacimientoParameter = fechaNacimiento != null ?
                new ObjectParameter("FechaNacimiento", fechaNacimiento) :
                new ObjectParameter("FechaNacimiento", typeof(string));
    
            var nSSParameter = nSS != null ?
                new ObjectParameter("NSS", nSS) :
                new ObjectParameter("NSS", typeof(string));
    
            var fechaIngresoParameter = fechaIngreso != null ?
                new ObjectParameter("FechaIngreso", fechaIngreso) :
                new ObjectParameter("FechaIngreso", typeof(string));
    
            var fotoParameter = foto != null ?
                new ObjectParameter("Foto", foto) :
                new ObjectParameter("Foto", typeof(string));
    
            var idEmpresaParameter = idEmpresa.HasValue ?
                new ObjectParameter("IdEmpresa", idEmpresa) :
                new ObjectParameter("IdEmpresa", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("EmpleadoAdd", numeroEmpleadoParameter, rCFParameter, nombreParameter, apellidoPaternoParameter, apellidoMaternoParameter, emailParameter, telefonoParameter, fechaNacimientoParameter, nSSParameter, fechaIngresoParameter, fotoParameter, idEmpresaParameter, mensaje, idEmpleado);
        }
    
        public virtual int EmpleadoDelete(string numeroEmpleado, ObjectParameter mensaje)
        {
            var numeroEmpleadoParameter = numeroEmpleado != null ?
                new ObjectParameter("NumeroEmpleado", numeroEmpleado) :
                new ObjectParameter("NumeroEmpleado", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("EmpleadoDelete", numeroEmpleadoParameter, mensaje);
        }
    
        public virtual ObjectResult<EmpleadoGet_Result> EmpleadoGet(string numeroEmpleado)
        {
            var numeroEmpleadoParameter = numeroEmpleado != null ?
                new ObjectParameter("NumeroEmpleado", numeroEmpleado) :
                new ObjectParameter("NumeroEmpleado", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<EmpleadoGet_Result>("EmpleadoGet", numeroEmpleadoParameter);
        }
    
        public virtual int EmpleadoUpdate(string numeroEmpleado, string rCF, string nombre, string apellidoPaterno, string apellidoMaterno, string email, string telefono, string fechaNacimiento, string nSS, string fechaIngreso, string foto, Nullable<int> idEmpresa, ObjectParameter mensaje)
        {
            var numeroEmpleadoParameter = numeroEmpleado != null ?
                new ObjectParameter("NumeroEmpleado", numeroEmpleado) :
                new ObjectParameter("NumeroEmpleado", typeof(string));
    
            var rCFParameter = rCF != null ?
                new ObjectParameter("RCF", rCF) :
                new ObjectParameter("RCF", typeof(string));
    
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var apellidoPaternoParameter = apellidoPaterno != null ?
                new ObjectParameter("ApellidoPaterno", apellidoPaterno) :
                new ObjectParameter("ApellidoPaterno", typeof(string));
    
            var apellidoMaternoParameter = apellidoMaterno != null ?
                new ObjectParameter("ApellidoMaterno", apellidoMaterno) :
                new ObjectParameter("ApellidoMaterno", typeof(string));
    
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            var telefonoParameter = telefono != null ?
                new ObjectParameter("Telefono", telefono) :
                new ObjectParameter("Telefono", typeof(string));
    
            var fechaNacimientoParameter = fechaNacimiento != null ?
                new ObjectParameter("FechaNacimiento", fechaNacimiento) :
                new ObjectParameter("FechaNacimiento", typeof(string));
    
            var nSSParameter = nSS != null ?
                new ObjectParameter("NSS", nSS) :
                new ObjectParameter("NSS", typeof(string));
    
            var fechaIngresoParameter = fechaIngreso != null ?
                new ObjectParameter("FechaIngreso", fechaIngreso) :
                new ObjectParameter("FechaIngreso", typeof(string));
    
            var fotoParameter = foto != null ?
                new ObjectParameter("Foto", foto) :
                new ObjectParameter("Foto", typeof(string));
    
            var idEmpresaParameter = idEmpresa.HasValue ?
                new ObjectParameter("IdEmpresa", idEmpresa) :
                new ObjectParameter("IdEmpresa", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("EmpleadoUpdate", numeroEmpleadoParameter, rCFParameter, nombreParameter, apellidoPaternoParameter, apellidoMaternoParameter, emailParameter, telefonoParameter, fechaNacimientoParameter, nSSParameter, fechaIngresoParameter, fotoParameter, idEmpresaParameter, mensaje);
        }
    
        public virtual int EmpresaAdd(string nombre, string telefono, string email, string direccionWeb, string logo, ObjectParameter mensaje, ObjectParameter idEmpresa)
        {
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var telefonoParameter = telefono != null ?
                new ObjectParameter("Telefono", telefono) :
                new ObjectParameter("Telefono", typeof(string));
    
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            var direccionWebParameter = direccionWeb != null ?
                new ObjectParameter("DireccionWeb", direccionWeb) :
                new ObjectParameter("DireccionWeb", typeof(string));
    
            var logoParameter = logo != null ?
                new ObjectParameter("Logo", logo) :
                new ObjectParameter("Logo", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("EmpresaAdd", nombreParameter, telefonoParameter, emailParameter, direccionWebParameter, logoParameter, mensaje, idEmpresa);
        }
    
        public virtual int EmpresaDelete(Nullable<int> idEmpresa, ObjectParameter mensaje)
        {
            var idEmpresaParameter = idEmpresa.HasValue ?
                new ObjectParameter("IdEmpresa", idEmpresa) :
                new ObjectParameter("IdEmpresa", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("EmpresaDelete", idEmpresaParameter, mensaje);
        }
    
        public virtual ObjectResult<EmpresaGet_Result> EmpresaGet(Nullable<int> idEmpresa, string nombre)
        {
            var idEmpresaParameter = idEmpresa.HasValue ?
                new ObjectParameter("IdEmpresa", idEmpresa) :
                new ObjectParameter("IdEmpresa", typeof(int));
    
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<EmpresaGet_Result>("EmpresaGet", idEmpresaParameter, nombreParameter);
        }
    
        public virtual int EmpresaUpdate(string nombre, string telefono, string email, string direccionWeb, string logo, Nullable<int> idEmpresa, ObjectParameter mensaje)
        {
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var telefonoParameter = telefono != null ?
                new ObjectParameter("Telefono", telefono) :
                new ObjectParameter("Telefono", typeof(string));
    
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            var direccionWebParameter = direccionWeb != null ?
                new ObjectParameter("DireccionWeb", direccionWeb) :
                new ObjectParameter("DireccionWeb", typeof(string));
    
            var logoParameter = logo != null ?
                new ObjectParameter("Logo", logo) :
                new ObjectParameter("Logo", typeof(string));
    
            var idEmpresaParameter = idEmpresa.HasValue ?
                new ObjectParameter("IdEmpresa", idEmpresa) :
                new ObjectParameter("IdEmpresa", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("EmpresaUpdate", nombreParameter, telefonoParameter, emailParameter, direccionWebParameter, logoParameter, idEmpresaParameter, mensaje);
        }
    
        public virtual ObjectResult<EstadoCivilGet_Result> EstadoCivilGet(Nullable<int> idEstadoCivil)
        {
            var idEstadoCivilParameter = idEstadoCivil.HasValue ?
                new ObjectParameter("IdEstadoCivil", idEstadoCivil) :
                new ObjectParameter("IdEstadoCivil", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<EstadoCivilGet_Result>("EstadoCivilGet", idEstadoCivilParameter);
        }
    
        public virtual ObjectResult<EstadoGetByIdPais_Result> EstadoGetByIdPais(Nullable<int> idPais)
        {
            var idPaisParameter = idPais.HasValue ?
                new ObjectParameter("IdPais", idPais) :
                new ObjectParameter("IdPais", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<EstadoGetByIdPais_Result>("EstadoGetByIdPais", idPaisParameter);
        }
    
        public virtual ObjectResult<MunicipioGetByIdEstado_Result> MunicipioGetByIdEstado(Nullable<int> idEstado)
        {
            var idEstadoParameter = idEstado.HasValue ?
                new ObjectParameter("IdEstado", idEstado) :
                new ObjectParameter("IdEstado", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MunicipioGetByIdEstado_Result>("MunicipioGetByIdEstado", idEstadoParameter);
        }
    
        public virtual ObjectResult<PaisGetAll_Result> PaisGetAll(Nullable<int> idPais)
        {
            var idPaisParameter = idPais.HasValue ?
                new ObjectParameter("IdPais", idPais) :
                new ObjectParameter("IdPais", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<PaisGetAll_Result>("PaisGetAll", idPaisParameter);
        }
    
        public virtual ObjectResult<RolGet_Result> RolGet(Nullable<int> idRol)
        {
            var idRolParameter = idRol.HasValue ?
                new ObjectParameter("IdRol", idRol) :
                new ObjectParameter("IdRol", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<RolGet_Result>("RolGet", idRolParameter);
        }
    
        public virtual int UsuarioAdd(string nombre, string apellidoPaterno, string apellidoMaterno, string sexo, string fechaNacimiento, string email, string password, string userName, Nullable<byte> idRol, string telefono, string celular, string cURP, string imagen, string calle, string numeroInterior, string numeroExterior, Nullable<int> idColonia, ObjectParameter mensaje, ObjectParameter idUsuario)
        {
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var apellidoPaternoParameter = apellidoPaterno != null ?
                new ObjectParameter("ApellidoPaterno", apellidoPaterno) :
                new ObjectParameter("ApellidoPaterno", typeof(string));
    
            var apellidoMaternoParameter = apellidoMaterno != null ?
                new ObjectParameter("ApellidoMaterno", apellidoMaterno) :
                new ObjectParameter("ApellidoMaterno", typeof(string));
    
            var sexoParameter = sexo != null ?
                new ObjectParameter("Sexo", sexo) :
                new ObjectParameter("Sexo", typeof(string));
    
            var fechaNacimientoParameter = fechaNacimiento != null ?
                new ObjectParameter("FechaNacimiento", fechaNacimiento) :
                new ObjectParameter("FechaNacimiento", typeof(string));
    
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("Password", password) :
                new ObjectParameter("Password", typeof(string));
    
            var userNameParameter = userName != null ?
                new ObjectParameter("UserName", userName) :
                new ObjectParameter("UserName", typeof(string));
    
            var idRolParameter = idRol.HasValue ?
                new ObjectParameter("IdRol", idRol) :
                new ObjectParameter("IdRol", typeof(byte));
    
            var telefonoParameter = telefono != null ?
                new ObjectParameter("Telefono", telefono) :
                new ObjectParameter("Telefono", typeof(string));
    
            var celularParameter = celular != null ?
                new ObjectParameter("Celular", celular) :
                new ObjectParameter("Celular", typeof(string));
    
            var cURPParameter = cURP != null ?
                new ObjectParameter("CURP", cURP) :
                new ObjectParameter("CURP", typeof(string));
    
            var imagenParameter = imagen != null ?
                new ObjectParameter("Imagen", imagen) :
                new ObjectParameter("Imagen", typeof(string));
    
            var calleParameter = calle != null ?
                new ObjectParameter("Calle", calle) :
                new ObjectParameter("Calle", typeof(string));
    
            var numeroInteriorParameter = numeroInterior != null ?
                new ObjectParameter("NumeroInterior", numeroInterior) :
                new ObjectParameter("NumeroInterior", typeof(string));
    
            var numeroExteriorParameter = numeroExterior != null ?
                new ObjectParameter("NumeroExterior", numeroExterior) :
                new ObjectParameter("NumeroExterior", typeof(string));
    
            var idColoniaParameter = idColonia.HasValue ?
                new ObjectParameter("IdColonia", idColonia) :
                new ObjectParameter("IdColonia", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UsuarioAdd", nombreParameter, apellidoPaternoParameter, apellidoMaternoParameter, sexoParameter, fechaNacimientoParameter, emailParameter, passwordParameter, userNameParameter, idRolParameter, telefonoParameter, celularParameter, cURPParameter, imagenParameter, calleParameter, numeroInteriorParameter, numeroExteriorParameter, idColoniaParameter, mensaje, idUsuario);
        }
    
        public virtual int UsuarioChangeStatus(Nullable<int> idUsuario, ObjectParameter mensaje)
        {
            var idUsuarioParameter = idUsuario.HasValue ?
                new ObjectParameter("IdUsuario", idUsuario) :
                new ObjectParameter("IdUsuario", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UsuarioChangeStatus", idUsuarioParameter, mensaje);
        }
    
        public virtual int UsuarioDelete(Nullable<int> idUsuario, ObjectParameter mensaje)
        {
            var idUsuarioParameter = idUsuario.HasValue ?
                new ObjectParameter("IdUsuario", idUsuario) :
                new ObjectParameter("IdUsuario", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UsuarioDelete", idUsuarioParameter, mensaje);
        }
    
        public virtual ObjectResult<UsuarioGet_Result> UsuarioGet(Nullable<int> idUsuario, string nombre, string apellidoPaterno, Nullable<byte> idRol)
        {
            var idUsuarioParameter = idUsuario.HasValue ?
                new ObjectParameter("IdUsuario", idUsuario) :
                new ObjectParameter("IdUsuario", typeof(int));
    
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var apellidoPaternoParameter = apellidoPaterno != null ?
                new ObjectParameter("ApellidoPaterno", apellidoPaterno) :
                new ObjectParameter("ApellidoPaterno", typeof(string));
    
            var idRolParameter = idRol.HasValue ?
                new ObjectParameter("IdRol", idRol) :
                new ObjectParameter("IdRol", typeof(byte));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<UsuarioGet_Result>("UsuarioGet", idUsuarioParameter, nombreParameter, apellidoPaternoParameter, idRolParameter);
        }
    
        public virtual int UsuarioUpdate(Nullable<int> idUsuario, string nombre, string apellidoPaterno, string apellidoMaterno, string sexo, string fechaNacimiento, string email, string password, string userName, Nullable<byte> idRol, string telefono, string celular, string cURP, string imagen, string calle, string numeroInterior, string numeroExterior, Nullable<int> idColonia, ObjectParameter mensaje)
        {
            var idUsuarioParameter = idUsuario.HasValue ?
                new ObjectParameter("IdUsuario", idUsuario) :
                new ObjectParameter("IdUsuario", typeof(int));
    
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var apellidoPaternoParameter = apellidoPaterno != null ?
                new ObjectParameter("ApellidoPaterno", apellidoPaterno) :
                new ObjectParameter("ApellidoPaterno", typeof(string));
    
            var apellidoMaternoParameter = apellidoMaterno != null ?
                new ObjectParameter("ApellidoMaterno", apellidoMaterno) :
                new ObjectParameter("ApellidoMaterno", typeof(string));
    
            var sexoParameter = sexo != null ?
                new ObjectParameter("Sexo", sexo) :
                new ObjectParameter("Sexo", typeof(string));
    
            var fechaNacimientoParameter = fechaNacimiento != null ?
                new ObjectParameter("FechaNacimiento", fechaNacimiento) :
                new ObjectParameter("FechaNacimiento", typeof(string));
    
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("Password", password) :
                new ObjectParameter("Password", typeof(string));
    
            var userNameParameter = userName != null ?
                new ObjectParameter("UserName", userName) :
                new ObjectParameter("UserName", typeof(string));
    
            var idRolParameter = idRol.HasValue ?
                new ObjectParameter("IdRol", idRol) :
                new ObjectParameter("IdRol", typeof(byte));
    
            var telefonoParameter = telefono != null ?
                new ObjectParameter("Telefono", telefono) :
                new ObjectParameter("Telefono", typeof(string));
    
            var celularParameter = celular != null ?
                new ObjectParameter("Celular", celular) :
                new ObjectParameter("Celular", typeof(string));
    
            var cURPParameter = cURP != null ?
                new ObjectParameter("CURP", cURP) :
                new ObjectParameter("CURP", typeof(string));
    
            var imagenParameter = imagen != null ?
                new ObjectParameter("Imagen", imagen) :
                new ObjectParameter("Imagen", typeof(string));
    
            var calleParameter = calle != null ?
                new ObjectParameter("Calle", calle) :
                new ObjectParameter("Calle", typeof(string));
    
            var numeroInteriorParameter = numeroInterior != null ?
                new ObjectParameter("NumeroInterior", numeroInterior) :
                new ObjectParameter("NumeroInterior", typeof(string));
    
            var numeroExteriorParameter = numeroExterior != null ?
                new ObjectParameter("NumeroExterior", numeroExterior) :
                new ObjectParameter("NumeroExterior", typeof(string));
    
            var idColoniaParameter = idColonia.HasValue ?
                new ObjectParameter("IdColonia", idColonia) :
                new ObjectParameter("IdColonia", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UsuarioUpdate", idUsuarioParameter, nombreParameter, apellidoPaternoParameter, apellidoMaternoParameter, sexoParameter, fechaNacimientoParameter, emailParameter, passwordParameter, userNameParameter, idRolParameter, telefonoParameter, celularParameter, cURPParameter, imagenParameter, calleParameter, numeroInteriorParameter, numeroExteriorParameter, idColoniaParameter, mensaje);
        }
    
        public virtual ObjectResult<UsuarioGetByUserNameEmail_Result> UsuarioGetByUserNameEmail(string userNameEmail, ObjectParameter mensaje, ObjectParameter found)
        {
            var userNameEmailParameter = userNameEmail != null ?
                new ObjectParameter("UserNameEmail", userNameEmail) :
                new ObjectParameter("UserNameEmail", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<UsuarioGetByUserNameEmail_Result>("UsuarioGetByUserNameEmail", userNameEmailParameter, mensaje, found);
        }
    }
}
