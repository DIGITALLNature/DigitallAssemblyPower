// Copyright (c) DIGITALL Nature.All rights reserved
// DIGITALL Nature licenses this file to you under the Microsoft Public License.

using Digitall.Plugins;
// ReSharper disable UnusedVariable
// ReSharper disable UnusedType.Global

namespace SamplePlugin
{
    public class ExecutorSample : Executor
    {
        /// <summary>
        /// Executes the main logic of the class.
        /// </summary>
        /// <returns>
        /// The result of the execution.
        /// </returns>
        protected override ExecutionResult Execute()
        {
            // Get the ID of the entity
            var entityId = Entity.Id;

            // Return the execution result
            return ExecutionResult.Skipped;
        }
    }
}
