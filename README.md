# Elasticsearch With DotNet
In this repo, I have developed a sample project on how we can use the Elasticsearch platform in a .Net project and make improvements.

## What is Elasticsearch?
 ElasticSearch is an open source, REST architecture search and analysis engine that provides users with a fast and reliable search experience. Developed by Shay Banon in 2010, ElasticSearch responds to modern data management and analysis needs.

Using a JSON-based data format and built on a powerful Apache Lucene infrastructure, this tool offers near real-time data search capacity. Users benefit from this structure in many areas such as big data applications, log management, analysis systems and content management systems.

<img src="https://github.com/user-attachments/assets/647c4ffb-15a5-47e4-9bdd-d527b4f154ca" width="500" height="300">


## What is Elasticsearch used for?
Elasticsearch’s speed, scalability, and ability to index many types of content enable a variety of use cases, including:

- Application search
- Website search
- Enterprise search
- Logging and log analysis
- Infrastructure metrics and container monitoring
- Application performance monitoring
- Geodata analysis and visualization
- Security analytics
- Business analytics

## What are Elasticsearch Components?
Elasticsearch consists of several core components that manage the processes of storing, indexing, and searching data. These components provide the distributed structure and scalability of the system. Here are the main components of Elasticsearch:

<img src="https://github.com/user-attachments/assets/20119091-6ec1-44d3-83cc-f105ea28e1af" width="500" height="300">

 ### Cluster
 A top-level structure consisting of multiple nodes. Manages data and indices, ensuring high availability and scalability. Each cluster has a unique name, and all nodes must belong to the same cluster.

### Node
  An instance of Elasticsearch that stores data, indexes, and processes queries. Can operate independently or as part of a cluster. Nodes can serve different roles, such as Master Node or Data Node

###  Index
 A collection of data stored in a structured format. Each index contains one or more shards and is used to store and query data.

### Document
The smallest unit of data, stored in JSON format. Represents a record and has a unique identifier (ID). Stored within an index.

### Shard
 A physical partition of an index, distributed across nodes for efficient data management and high availability. Types:
- Primary Shard: Original data copy.
- Replica Shard: A copy of the primary shard for redundancy.

### Mapping
  Defines the data structure and field types within an index, such as number, text, or date. Essential for schema definition and accurate data search.

 ### Analyzer
 Processes text data by breaking it into tokens and optimizing it for search. Customizable for different fields (e.g., title vs. description).
 
### Query DSL
 JSON-based query language used for complex searches, filters, and analyses in Elasticsearch. Includes query types like match, term, and range.

### Inverted Index
Data structure used for fast full-text searches by mapping words to the documents they appear in.

### Snapshot and Restore
 Snapshots are backups of clusters or indices. Restoring these backups enables data recovery and long-term protection.

### Elasticsearch Plugins
  Extend Elasticsearch functionality with additional features, such as data processing (Ingest Node) or security (X-Pack).
 

