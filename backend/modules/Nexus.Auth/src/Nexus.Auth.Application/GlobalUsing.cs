global using MediatR;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.Extensions.Configuration;
global using Microsoft.IdentityModel.Tokens;
global using Nexus.Auth.Application.Models;
global using Nexus.Auth.Infra.Persistence;
global using Nexus.Core.Application.Models.Jwt;
global using System.IdentityModel.Tokens.Jwt;
global using System.Security.Claims;
global using System.Text;
global using Microsoft.AspNetCore.Http;
global using static Microsoft.AspNetCore.Http.Results;
global using Microsoft.AspNetCore.Identity;
global using Nexus.Auth.Domain.Entities;
global using System.Diagnostics.CodeAnalysis;
global using System.Reflection;
global using FluentValidation;
global using Microsoft.Extensions.DependencyInjection;
global using Nexus.Auth.Infra.Data.Connection;
global using Nexus.Auth.Infra.Extensions;