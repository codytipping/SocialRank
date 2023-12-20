# SocialRank

Social RankSocial Rank
Jun 2023 - PresentJun 2023 - Present

Inspired by Google's PageRank algorithm, I created Social Rank to work with Artificial Intelligence to reveal how powerful ideas can influence the minds’ of others in any given domain. 

It works by dynamically generating a markov chain based on a search query. Then, it runs through several simulations until stable values are reached for each node in the network. 

Here’s how the algorithm works:

1. Social Rank compiles a list of content based on the query. Each item is associated with one author.
2. Although content is initially considered for the network, every author is represented as a node, instead. 
3. Edges are determined by peer-to-content approval. If content has been approved, then only those individuals that are also nodes in the network will be considered as edges.
4. The algorithm assigns a numerical weight, or Social Rank score, to each author. The authors with more inbound approval will be considered more authoritative for the relevant domain. 
5. Social Rank considers both quantity and quality of links between authors: A link from a higher Social Rank is given more weight than that from a lower Social Rank.
