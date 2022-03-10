using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using MediatR;

namespace Application.Features.Ingreso.Commands.Create
{
    public class CreateIngresoCommand: IRequest<Response<int>>
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Identification { get; set; }
        public string House { get; set; }
        public DateTime FechaNacimiento { get; set; }
    }

    public class CreateIngresoCommandHandler : IRequestHandler<CreateIngresoCommand, Response<int>>
    {
        private readonly IRepositoryAsync<Domain.Entities.Ingreso> _repositoryAsync;
        private readonly IMapper _mapper;

        public CreateIngresoCommandHandler(IRepositoryAsync<Domain.Entities.Ingreso> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateIngresoCommand request, CancellationToken cancellationToken)
        {
            var nuevoRegistro = _mapper.Map<Domain.Entities.Ingreso>(request);
            var data = await _repositoryAsync.AddAsync(nuevoRegistro);

            return new Response<int>(data.Id);
        }
    }
}
