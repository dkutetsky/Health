﻿// <copyright file="HealthRoot.cs" company="Allan Hardy">
// Copyright (c) Allan Hardy. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using App.Metrics.Health.Formatters;

namespace App.Metrics.Health
{
    public class HealthRoot : IHealthRoot, IHealth
    {
        private readonly IHealth _health;

        public HealthRoot(
            IHealth health,
            HealthOptions options,
            HealthFormatterCollection metricsOutputFormatters,
            IHealthOutputFormatter defaultMetricsOutputFormatter,
            IRunHealthChecks healthCheckRunner)
        {
            Options = options ?? throw new ArgumentNullException(nameof(options));
            _health = health ?? throw new ArgumentNullException(nameof(health));
            OutputHealthFormatters = metricsOutputFormatters ?? new HealthFormatterCollection();
            DefaultOutputHealthFormatter = defaultMetricsOutputFormatter;
            HealthCheckRunner = healthCheckRunner;
        }

        /// <inheritdoc />
        public IReadOnlyCollection<IHealthOutputFormatter> OutputHealthFormatters { get; }

        /// <inheritdoc />
        public IHealthOutputFormatter DefaultOutputHealthFormatter { get; }

        /// <inheritdoc />
        public HealthOptions Options { get; }

        /// <inheritdoc />
        public IRunHealthChecks HealthCheckRunner { get; }

        /// <inheritdoc />
        public IEnumerable<HealthCheck> Checks => _health.Checks;
    }
}