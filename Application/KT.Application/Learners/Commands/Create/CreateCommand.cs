﻿using ErrorOr;
using KT.Domain.Common.ValueObjects;
using KT.Domain.LearnerAggregate;
using MediatR;

namespace KT.Application.Learners.Commands.Create;

public record CreateCommand(
    string Forename,
    string Surname,
    DateOnly DateOfBirth,
    Address Address,
    ContactDetails ContactDetails) 
    : IRequest<ErrorOr<Learner>>;