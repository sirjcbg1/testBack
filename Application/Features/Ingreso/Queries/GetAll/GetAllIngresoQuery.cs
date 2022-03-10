using Application.DTOs;
using Application.Interfaces;
using Application.Specifications;
using Application.Wrappers;
using AutoMapper;
using MediatR;


namespace Application.Features.Ingreso.Queries.GetAll
{
    public class GetAllIngresoQuery : IRequest<PagedResponse<List<IngresoDto>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public class GetAllIngresoQueryHandler : IRequestHandler<GetAllIngresoQuery, PagedResponse<List<IngresoDto>>>
        {
            private readonly IRepositoryAsync<Domain.Entities.Ingreso> _repositoryAsync;
            private readonly IMapper _mapper;

            public GetAllIngresoQueryHandler(IRepositoryAsync<Domain.Entities.Ingreso> repositoryAsync, IMapper mapper)
            {
                _repositoryAsync = repositoryAsync;
                _mapper = mapper;
            }

            public async Task<PagedResponse<List<IngresoDto>>> Handle(GetAllIngresoQuery request, CancellationToken cancellationToken)
            {
                var ingresos = await _repositoryAsync.ListAsync(new PagedIngresoSpecification(request.PageSize, request.PageNumber, request.Name, request.LastName));
                var ingresoDto = _mapper.Map<List<IngresoDto>>(ingresos);
                return new PagedResponse<List<IngresoDto>>(ingresoDto, request.PageNumber, request.PageSize);
            }
        }

    }
}
