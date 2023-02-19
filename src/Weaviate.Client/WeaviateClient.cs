﻿// Copyright (C) 2023 Search Pioneer - https://www.searchpioneer.com
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//         http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using SearchPioneer.Weaviate.Client.Api.Backup;
using SearchPioneer.Weaviate.Client.Api.Batch;
using SearchPioneer.Weaviate.Client.Api.Classifications;
using SearchPioneer.Weaviate.Client.Api.Cluster;
using SearchPioneer.Weaviate.Client.Api.Contextionary;
using SearchPioneer.Weaviate.Client.Api.Data;
using SearchPioneer.Weaviate.Client.Api.Graph;
using SearchPioneer.Weaviate.Client.Api.Misc;
using SearchPioneer.Weaviate.Client.Api.Schema;

namespace SearchPioneer.Weaviate.Client;

public class WeaviateClient
{
    private readonly DbVersionSupport _dbVersionSupport;
    private readonly Transport _transport;

    public WeaviateClient(Config config, HttpClient httpClient)
    {
        _transport = new(config, httpClient);

        // Get the version from the server
        var serverVersion = Misc.Meta().Result.Version;
        _dbVersionSupport = new(serverVersion);
    }

    public BackupApi Backup => new(_transport);
    public MiscApi Misc => new(_transport);
    public SchemaApi Schema => new(_transport);
    public DataApi Data => new(_transport, _dbVersionSupport);
    public ReferenceApi Reference => new(_transport, _dbVersionSupport);
    public BatchApi Batch => new(_transport, _dbVersionSupport);
    public ContextionaryApi Contextionary => new(_transport);
    public ClassificationsApi Classification => new(_transport);
    public GraphApi Graph => new(_transport);
    public ClusterApi Cluster => new(_transport);
}