using Application.DTOs;
using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Ingreso.Queries.GetById
{
    public class GetIngresoByIdQuery : IRequest<Response<IngresoDto>>
    {
        public int Id { get; set; }

        public class GetIngresoByIdQueryHandler : IRequestHandler<GetIngresoByIdQuery,Response<IngresoDto>>
        {
            private readonly IRepositoryAsync<Domain.Entities.Ingreso> _repositoryAsync;
            private readonly IMapper _mapper;

            public GetIngresoByIdQueryHandler(IRepositoryAsync<Domain.Entities.Ingreso> repositoryAsync, IMapper mapper)
            {
                _repositoryAsync = repositoryAsync;
                _mapper = mapper;
            }

            public async Task<Response<IngresoDto>> Handle(GetIngresoByIdQuery request, CancellationToken cancellationToken)
            {
                var ingreso = await _repositoryAsync.GetByIdAsync(request.Id);
                if (ingreso == null)
                {
                    throw new KeyNotFoundException($"Registro no encontrado con el id {request.Id}");
                }
                else
                {
                    var dto = _mapper.Map<IngresoDto>(ingreso);
                    return new Response<IngresoDto>(dto);
                }

            }
        }


    }
}
