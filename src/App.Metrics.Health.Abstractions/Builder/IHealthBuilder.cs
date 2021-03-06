﻿// <copyright file="IHealthBuilder.cs" company="Allan Hardy">
// Copyright (c) Allan Hardy. All rights reserved.
// </copyright>

// ReSharper disable CheckNamespace
namespace App.Metrics.Health
    // ReSharper restore CheckNamespace
{
    public interface IHealthBuilder
    {
        /// <summary>
        ///     Builder for configuring core App Metrics Health options.
        /// </summary>
        IHealthConfigurationBuilder Configuration { get; }

        IHealthCheckBuilder HealthChecks { get; }

        /// <summary>
        ///     <para>
        ///         Builder for configuring health check output formatting for reporting.
        ///     </para>
        ///     <para>
        ///         Multiple formatters can be used, in which case the <see cref="IHealthRoot.DefaultOutputHealthFormatter" />
        ///         will be set to the first configured formatter.
        ///     </para>
        /// </summary>
        IHealthOutputFormattingBuilder OutputHealth { get; }

        /// <summary>
        ///     Builds an <see cref="IHealth" /> with the services configured via an <see cref="IHealthBuilder" />.
        /// </summary>
        /// <returns>An <see cref="IHealthRoot" /> with services configured via an <see cref="IHealthBuilder" />.</returns>
        IHealthRoot Build();
    }
}