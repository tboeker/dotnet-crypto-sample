# dotnet-crypto-sample

Demo der Asymmetrischen Verschlüsselung.

# Test and Run

```
# create certificate
dotnet run --project create-cert

# create demo data
dotnet run --project demo-data
```

# Prinzip

* Dritte Person erstellt Zertifikat (CreateCert).
* App verschlüsselt Daten mit dem Zertifikat.
* Dritte Person liest Daten und entschlüsselt sie mit dem Private Key


# Notizen und Links

- https://github.com/damienbod/SendingEncryptedData

- https://dev.to/stratiteq/cryptography-with-practical-examples-in-net-core-1mc4

- https://github.com/damienbod/AspNetCoreCertificates

- https://www.c-sharpcorner.com/article/implement-symmetric-and-asymmetric-cryptography-algorithms-with-c-sharp/