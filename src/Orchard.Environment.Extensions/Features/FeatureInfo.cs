﻿using Microsoft.DotNet.ProjectModel.FileSystemGlobbing;
using Microsoft.Extensions.FileProviders;
using System;
using System.Linq;

namespace Orchard.Environment.Extensions.Features
{
    public class FeatureInfo : IFeatureInfo
    {
        private string _id;
        private string _name;
        private double _priority;
        private IExtensionInfo _extension;
        private string[] _dependencies;

        public FeatureInfo(
            string id,
            string name,
            double priority,
            IExtensionInfo extension,
            string[] dependencies)
        {
            _id = id;
            _name = name;
            _priority = priority;
            _extension = extension;
            _dependencies = dependencies;
        }

        public string Id { get { return _id; } }
        public string Name { get { return _name; } }
        public double Priority { get { return _priority; } }
        public IExtensionInfo Extension { get { return _extension; } }
        public string[] Dependencies { get { return _dependencies; } }

        public bool DependencyOn(IFeatureInfo subject)
        {
            return this.Dependencies.Any(x =>
                StringComparer.OrdinalIgnoreCase.Equals(x, subject.Id));
        }
    }
}