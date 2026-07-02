# [2.0.0](https://github.com/DIGITALLNature/DigitallAssemblyPower/compare/v1.0.0...v2.0.0) (2026-07-02)


* feat!: standardize namespaces ([0866532](https://github.com/DIGITALLNature/DigitallAssemblyPower/commit/08665322cf2f7415ca91421c05186a0d209b10aa))


### Bug Fixes

* address PR review feedback on null safety and scope handling ([44841c9](https://github.com/DIGITALLNature/DigitallAssemblyPower/commit/44841c9bb1cbe38f4f5237ab62e7d4046eddfcfa))
* address Qodana static analysis issues ([db58f78](https://github.com/DIGITALLNature/DigitallAssemblyPower/commit/db58f7854f31d306d7a4b4886177eb88775db1f4))
* crm sdk only development dependency ([09d2b14](https://github.com/DIGITALLNature/DigitallAssemblyPower/commit/09d2b14b9c02d286277e8e895ecf7fa768b556bf))
* expose TimeProvider for easy usage in unit tests ([470fab9](https://github.com/DIGITALLNature/DigitallAssemblyPower/commit/470fab97b1d401dc2a65292a2d4fa75a4ff182c8))
* resolve all static analyzer errors and suppress C# 14 extension false positives ([86797c0](https://github.com/DIGITALLNature/DigitallAssemblyPower/commit/86797c02219cb3f8e43a4dffa0b029c7ca732bcf))
* reuse IOrganizationService instances in Executor ([90dd4ec](https://github.com/DIGITALLNature/DigitallAssemblyPower/commit/90dd4ec03ffd3589ed9cdc6408d9e7e788899bdc))
* suppress false-positive NRE after non-null assertion in BeginScope test ([2bf5ba5](https://github.com/DIGITALLNature/DigitallAssemblyPower/commit/2bf5ba5d158222ee4e6647ae4c8f12a42dce9432))
* TimeProvider dependency ([ab6d8c0](https://github.com/DIGITALLNature/DigitallAssemblyPower/commit/ab6d8c0ba82f45b6742b7bc760aca81b29c6bb9e))
* TimeProvider package dependency ([c6a503c](https://github.com/DIGITALLNature/DigitallAssemblyPower/commit/c6a503c9306df37b9af32c12a9c0d91a9a741f7b))
* use logger delegates ([9d07543](https://github.com/DIGITALLNature/DigitallAssemblyPower/commit/9d07543275e004ca2c9a2d8d38e7ff61c2b39dfc))


### Features

* add extension method for managed identity service ([58ad24e](https://github.com/DIGITALLNature/DigitallAssemblyPower/commit/58ad24e1b90c167957759641e0dde246d777ea54))
* add extension methods for new bulk operations ([5422440](https://github.com/DIGITALLNature/DigitallAssemblyPower/commit/5422440fbff86c53af1f59cf8d21c8dcf57d1659))
* add RegisterProxyTypesAssembly Extension ([c5311e0](https://github.com/DIGITALLNature/DigitallAssemblyPower/commit/c5311e072fe6421c4f6ab7d2d88968554c13b2fc))
* add support for multiple log sinks ([23694bb](https://github.com/DIGITALLNature/DigitallAssemblyPower/commit/23694bb15f410b81b3f2b99b62bdcfa8d933ec25))
* DateTimeProvider ([#7](https://github.com/DIGITALLNature/DigitallAssemblyPower/issues/7)) ([d5ade50](https://github.com/DIGITALLNature/DigitallAssemblyPower/commit/d5ade5066d5395774cb7f152b43ecc0bb40be50a))
* expose TimeProvider via IServiceProvider ([b4bb496](https://github.com/DIGITALLNature/DigitallAssemblyPower/commit/b4bb4966a6d26de055f37c0116925d5b08cd2eec))
* **PluginCore:** change PluginExecutionContext tp IPluginExecutionContext4 ([9afe351](https://github.com/DIGITALLNature/DigitallAssemblyPower/commit/9afe351b0d06b99d3500459b1e4eab6c5af47e4a))
* union all moduls ([3222ee6](https://github.com/DIGITALLNature/DigitallAssemblyPower/commit/3222ee677ea297f9dc87d3b44fec77700daed2b7))
* update GetExecutionContext to use IPluginExecutionContext7 ([33aa152](https://github.com/DIGITALLNature/DigitallAssemblyPower/commit/33aa15250c391ff0c68755271e30179a4b13108c))


### BREAKING CHANGES

* Renames package, solution, project paths, and namespaces from Digitall.APower to Digitall.Plugins.

# [2.0.0-beta.1](https://github.com/DIGITALLNature/DigitallAssemblyPower/compare/v1.1.0-beta.6...v2.0.0-beta.1) (2026-07-02)


* feat!: standardize namespaces ([0866532](https://github.com/DIGITALLNature/DigitallAssemblyPower/commit/08665322cf2f7415ca91421c05186a0d209b10aa))


### Bug Fixes

* address PR review feedback on null safety and scope handling ([44841c9](https://github.com/DIGITALLNature/DigitallAssemblyPower/commit/44841c9bb1cbe38f4f5237ab62e7d4046eddfcfa))
* address Qodana static analysis issues ([db58f78](https://github.com/DIGITALLNature/DigitallAssemblyPower/commit/db58f7854f31d306d7a4b4886177eb88775db1f4))
* resolve all static analyzer errors and suppress C# 14 extension false positives ([86797c0](https://github.com/DIGITALLNature/DigitallAssemblyPower/commit/86797c02219cb3f8e43a4dffa0b029c7ca732bcf))
* suppress false-positive NRE after non-null assertion in BeginScope test ([2bf5ba5](https://github.com/DIGITALLNature/DigitallAssemblyPower/commit/2bf5ba5d158222ee4e6647ae4c8f12a42dce9432))
* TimeProvider package dependency ([c6a503c](https://github.com/DIGITALLNature/DigitallAssemblyPower/commit/c6a503c9306df37b9af32c12a9c0d91a9a741f7b))
* use logger delegates ([9d07543](https://github.com/DIGITALLNature/DigitallAssemblyPower/commit/9d07543275e004ca2c9a2d8d38e7ff61c2b39dfc))


### Features

* add extension method for managed identity service ([58ad24e](https://github.com/DIGITALLNature/DigitallAssemblyPower/commit/58ad24e1b90c167957759641e0dde246d777ea54))
* add extension methods for new bulk operations ([5422440](https://github.com/DIGITALLNature/DigitallAssemblyPower/commit/5422440fbff86c53af1f59cf8d21c8dcf57d1659))
* add support for multiple log sinks ([23694bb](https://github.com/DIGITALLNature/DigitallAssemblyPower/commit/23694bb15f410b81b3f2b99b62bdcfa8d933ec25))


### BREAKING CHANGES

* Renames package, solution, project paths, and namespaces from Digitall.APower to Digitall.Plugins.

# [1.1.0-beta.6](https://github.com/DIGITALLNature/DigitallAssemblyPower/compare/v1.1.0-beta.5...v1.1.0-beta.6) (2026-06-16)


### Bug Fixes

* expose TimeProvider for easy usage in unit tests ([470fab9](https://github.com/DIGITALLNature/DigitallAssemblyPower/commit/470fab97b1d401dc2a65292a2d4fa75a4ff182c8))


### Features

* expose TimeProvider via IServiceProvider ([b4bb496](https://github.com/DIGITALLNature/DigitallAssemblyPower/commit/b4bb4966a6d26de055f37c0116925d5b08cd2eec))

# [1.1.0-beta.5](https://github.com/DIGITALLNature/DigitallAssemblyPower/compare/v1.1.0-beta.4...v1.1.0-beta.5) (2026-05-19)


### Bug Fixes

* TimeProvider dependency ([ab6d8c0](https://github.com/DIGITALLNature/DigitallAssemblyPower/commit/ab6d8c0ba82f45b6742b7bc760aca81b29c6bb9e))

# [1.1.0-beta.4](https://github.com/DIGITALLNature/DigitallAssemblyPower/compare/v1.1.0-beta.3...v1.1.0-beta.4) (2025-12-11)


### Bug Fixes

* reuse IOrganizationService instances in Executor ([90dd4ec](https://github.com/DIGITALLNature/DigitallAssemblyPower/commit/90dd4ec03ffd3589ed9cdc6408d9e7e788899bdc))

# [1.1.0-beta.3](https://github.com/DIGITALLNature/DigitallAssemblyPower/compare/v1.1.0-beta.2...v1.1.0-beta.3) (2025-02-27)


### Features

* add RegisterProxyTypesAssembly Extension ([c5311e0](https://github.com/DIGITALLNature/DigitallAssemblyPower/commit/c5311e072fe6421c4f6ab7d2d88968554c13b2fc))
* DateTimeProvider ([#7](https://github.com/DIGITALLNature/DigitallAssemblyPower/issues/7)) ([d5ade50](https://github.com/DIGITALLNature/DigitallAssemblyPower/commit/d5ade5066d5395774cb7f152b43ecc0bb40be50a))
* update GetExecutionContext to use IPluginExecutionContext7 ([33aa152](https://github.com/DIGITALLNature/DigitallAssemblyPower/commit/33aa15250c391ff0c68755271e30179a4b13108c))

# [1.1.0-beta.2](https://github.com/DIGITALLNature/DigitallAssemblyPower/compare/v1.1.0-beta.1...v1.1.0-beta.2) (2024-06-20)


### Features

* union all moduls ([3222ee6](https://github.com/DIGITALLNature/DigitallAssemblyPower/commit/3222ee677ea297f9dc87d3b44fec77700daed2b7))

# [1.1.0-beta.1](https://github.com/DIGITALLNature/DigitallAssemblyPower/compare/v1.0.1-beta.1...v1.1.0-beta.1) (2023-05-23)


### Features

* **PluginCore:** change PluginExecutionContext tp IPluginExecutionContext4 ([9afe351](https://github.com/DIGITALLNature/DigitallAssemblyPower/commit/9afe351b0d06b99d3500459b1e4eab6c5af47e4a))

## [1.0.1-beta.1](https://github.com/DIGITALLNature/DigitallAssemblyPower/compare/v1.0.0...v1.0.1-beta.1) (2023-05-23)


### Bug Fixes

* crm sdk only development dependency ([09d2b14](https://github.com/DIGITALLNature/DigitallAssemblyPower/commit/09d2b14b9c02d286277e8e895ecf7fa768b556bf))

# 1.0.0 (2023-05-22)


### Features

* initial Version ([e380ab1](https://github.com/DIGITALLNature/DigitallAssemblyPower/commit/e380ab157913046f8d29c940e01aad55e12b4de9))


# 1.0.0-beta.1 (2023-05-19)


### Features

* initial Version ([e380ab1](https://github.com/DIGITALLNature/DigitallAssemblyPower/commit/e380ab157913046f8d29c940e01aad55e12b4de9))
