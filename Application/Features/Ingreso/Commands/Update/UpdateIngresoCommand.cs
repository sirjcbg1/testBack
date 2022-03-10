using Application.Interfaces;
using Application.Wrappers;
using Domain.Entities;
using MediatR;

namespace Application.Features.Ingreso.Commands.Update
{
    public class UpdateIngresoCommand: IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string LastName { get; set; }
        public int Identification { get; set; }
        public string House { get; set; }
        public DateTime FechaNacimiento { get; set; }
    }

    public class UpdateIngresoCommandHandler : IRequestHandler<UpdateIngresoCommand, Response<int>>
    {
        private readonly IRepositoryAsync<Domain.Entities.Ingreso> _repositoryAsync;

        public UpdateIngresoCommandHandler(IRepositoryAsync<Domain.Entities.Ingreso> repositoryAsync)
        {
            _repositoryAsync = repositoryAsync;
        }

        public async Task<Response<int>> Handle(UpdateIngresoCommand request, CancellationToken cancellationToken)
        {
            var ingreso = await _repositoryAsync.GetByIdAsync(request.Id);

            if (ingreso == null)
            {
                throw new KeyNotFoundException($"Registro no encontrado con el id {request.Id}");
            }
            else
            {
                ingreso.Name = request.Nombre;
                ingreso.LastName = request.LastName;
                ingreso.Identification = request.Identification;
                ingreso.House = request.House;
                ingreso.FechaNacimiento = request.FechaNacimiento;
                await _repositoryAsync.UpdateAsync(ingreso);
                return new Response<int>(ingreso.Id);
            }
        }
    }
}
