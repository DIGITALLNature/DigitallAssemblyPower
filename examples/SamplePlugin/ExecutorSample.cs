// Copyright (c) DIGITALL Nature.All rights reserved
// DIGITALL Nature licenses this file to you under the Microsoft Public License.

using Digitall.APower;

namespace SamplePlugin
{
    public class ExecutorSample : Executor
    {
        protected override ExecutionResult Execute()
        {
            var entityId = Entity.Id;

            return ExecutionResult.Skipped;
        }
    }
}
