﻿namespace N_Tier.Application.Models;

public class PagedResult<T>
{
    public List<T> Items { get; set; } = new List<T>();
    public int TotalCount { get; set; }
    public int PageSize { get; set; }
    public int PageNumber { get; set; }

    public int TotalPages => (int)Math.Ceiling((double)TotalCount / PageSize);
}
