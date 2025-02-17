using System;
using Application.Tasks.DTOs;
using Application.Workspaces.DTOs;
using AutoMapper;
using Domain;

namespace Application.Core;

public class MappingProfiles: Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateWorkspaceDto, Workspace>();
        CreateMap<CreateTaskDto, TaskItem>();
    }
}
