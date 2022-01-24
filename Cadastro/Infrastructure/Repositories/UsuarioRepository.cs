using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Cadastro.Application.DataTransferObject;
using Cadastro.Domain.DataAccess;
using Cadastro.Domain.Entity;

namespace Cadastro.Infrastructure.Repositories
{
    public class UsuarioRepository : IUsuarioRepository

    {       
       private IUsuarioWriteRepository UsuarioWriteRepository { get; }
       private IUsuarioReadRepository UsuarioReadRepository { get; }

        public UsuarioRepository(
            IUsuarioWriteRepository usuarioWriteRepository,
            IUsuarioReadRepository usuarioReadRepository)
        {
            UsuarioWriteRepository = usuarioWriteRepository;
            UsuarioReadRepository = usuarioReadRepository;
        }

        public async Task<Usuario> Create(Usuario usuario, CancellationToken cancellationToken)
        {
            return await UsuarioWriteRepository.Create(usuario, cancellationToken);
        }

        public List<Usuario> GetUsuarioByNome(string nome)
        {
            return UsuarioReadRepository.GetUsuarioByNome(nome).ToList();
        }

        public bool Delete(int usuarioId)
        {
            return  UsuarioWriteRepository.Delete(usuarioId);
        }

        public Usuario GetUsuarioById(int usuarioId)
        {
            return  UsuarioReadRepository.GetUsuarioById(usuarioId);
        }
/*
        public bool Update(Domain.Entity.Beneficiary beneficiary)
        {
            Logger.Information<Domain.Entity.Beneficiary>("Calling the method BeneficiaryWriteRepository.Update", beneficiary);
            return  BeneficiaryWriteRepository.Update(beneficiary);
        }

        

        public List<Domain.Entity.Beneficiary> FindAllByUserId(int userId)
        {
            Logger.Information<int>("Calling the method BeneficiaryReadRepository.FindAllByUserId", userId);
            return  BeneficiaryReadRepository.FindAllByUserId(userId);
        }

        public List<Domain.Entity.Beneficiary> FindBeneficiariesByDebitAccount(List<string> accountsNumber)
        {
            Logger.Information<IList<string>>("Calling the method BeneficiaryReadRepository.FindBeneficiariesByDebitAccount", accountsNumber);
            return  BeneficiaryReadRepository.FindBeneficiariesByDebitAccount(accountsNumber);
        }
        public bool FindIfExistsBankAccount(string bankAccount)
        {
            Logger.Information<string>("Calling the method BeneficiaryReadRepository.FindIfExistsBankAccount", bankAccount);
            return  BeneficiaryReadRepository.FindIfExistsBankAccount(bankAccount);
        }

        public bool FindIfExistsBankAccountAndType(string bankAccount, string accountType)
        {
            Logger.Information<string>("Calling the method BeneficiaryReadRepository.FindIfExistsBankAccountAndType", bankAccount);
            return  BeneficiaryReadRepository.FindIfExistsBankAccountAndType(bankAccount, accountType);
        }

        public bool FindIfExistsBicSwift( string benefBankBic)
        {
            Logger.Information<string>("Calling the method BeneficiaryReadRepository.FindIfExistsBicSwift", benefBankBic);
            return  BeneficiaryReadRepository.FindIfExistsBicSwift(benefBankBic);
        }*/
    }
}