using System.Threading;
using System.Threading.Tasks;
using Cadastro.Domain.DataAccess;
using Cadastro.Domain.DataAccess.EntityFramework;
using Cadastro.Domain.Entity;
using Cadastro.Infrastructure.Repositories.EntityFramework.Context;

namespace Cadastro.Infrastructure.Repositories.EntityFramework
{
    public class UsuarioWriteRepository : IUsuarioWriteRepository
    {
        #region Properties
        private IGenericRepository<Usuario, UsuarioContext> UsuarioRepository { get; }

        #endregion

        #region Constructor
        public UsuarioWriteRepository(
            IGenericRepository<Usuario, UsuarioContext> usuarioRepository)
        {
            UsuarioRepository = usuarioRepository;
        }

        #endregion

        #region UsuarioWriteRepository implementation

        public async Task<Usuario> Create(Usuario usuario, CancellationToken cancellationToken)
        {      
            await UsuarioRepository.Add(usuario, cancellationToken);
            UsuarioRepository.Commit();
            return usuario;            
        }

       /* public bool Update(Domain.Entity.Beneficiary beneficiary)
        {
            try
            {
                Logger.Information<Domain.Entity.Beneficiary>("Updating a Beneficiary in BeneficiaryRepository", beneficiary);
                BeneficiaryRepository.Update(beneficiary);
                Logger.Information("Data updated in BeneficiaryRepository");
                BeneficiaryRepository.Commit();
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, $"An unexpected error ocurred: {ex.Message}", "HIGH", "HIGH");
                return false;
            }
        }



        public bool Delete(int beneficiaryId)
        {
            try
            {
                Logger.Information<int>("Find a Beneficiary in BeneficiaryRepository", beneficiaryId);
                var beneficiary = BeneficiaryRepository.First(x => x.Id == beneficiaryId);
                beneficiary.IsActive = 0;
                Logger.Information<Domain.Entity.Beneficiary>("Update a Order in BeneficiaryRepository", beneficiary);
                BeneficiaryRepository.Update(beneficiary);
                Logger.Information("Data updated in BeneficiaryRepository");
                BeneficiaryRepository.Commit();
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, $"An unexpected error ocurred: {ex.Message}", "HIGH", "HIGH");
                return false;
            }
        }*/

        #endregion
    }
}