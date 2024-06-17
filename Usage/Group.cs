using System;

namespace Usage;

public record Group(Guid Id, string? DisplayName, string? Description, DateTimeOffset CreatedDateTime);