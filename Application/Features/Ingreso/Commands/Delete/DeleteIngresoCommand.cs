using Application.Interfaces;
using Application.Wrappers;
using Domain.Entities;
using MediatR;

namespace Application.Features.Ingreso.Commands.Delete
{
    public class DeleteIngresoCommand: IRequest<Response<int>>
    {
        public int Id { get; set; }
    }

    public class DeleteIngresoCommandHandler : IRequestHandler<DeleteIngresoCommand, Response<int>>
    {
        private readonly IRepositoryAsync<Domain.Entities.Ingreso> _repositoryAsync;

        public DeleteIngresoCommandHandler(IRepositoryAsync<Domain.Entities.Ingreso> repositoryAsync)
        {
            _repositoryAsync = repositoryAsync;
        }

        public async Task<Response<int>> Handle(DeleteIngresoCommand request, CancellationToken cancellationToken)
        {

            var ingreso = await _repositoryAsync.GetByIdAsync(request.Id);

            if (ingreso == null)
            {
                throw new KeyNotFoundException($"Registro no encontrado con el id {request.Id}");
            }
            else
            {
                await _repositoryAsync.DeleteAsync(ingreso);
                return new Response<int>(ingreso.Id);
            }
        }
    }
}
