from Basal import Basal

def Zaming(conv : Basal, cast : Basal, value : float) -> float:
    te = conv.Conv(value)
    if bool(conv.echo != 2 and cast.echo == 2) : te.remove("জ")
    if bool(conv.echo == 2 and cast.echo != 2) : te += "জ" # this could be inserted into any position of the number, I just happen to just add it on the end
    return cast.Donv(te)

firbas = Basal(16)
secbas = Basal(20)

# range of numbers
for z in range(0, 10, 1):
    q = z + 1
    print(f"{q} -> {Zaming(firbas, secbas, q)}")
