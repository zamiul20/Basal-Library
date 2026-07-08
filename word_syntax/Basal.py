from math import log

class Basal:
    echo = polar = int(2)
    ripple = int(0)
    discretion = int(0)
    velocity = float(1)
    accuracy = int(30)

    num_value = int(0)
    base_value = int(10)
    number = "0"
    display = "<10T"

    def __init__(self,
                 bass : float,
                 vel : float | None = 1,
                 pol : int | None = 2,
                 dis : int | None = 0,
                 eco : int | None = 2,
                 rip_val : int | None = 2
                 ) -> None:        
        self.polar = pol
        self.discretion = dis
        self.echo = eco
        self.ripple = rip_val
        self.velocity = vel
        self.base_value = bass
        self.display = Basal.ct_disp(self)

    '''def __init__(self,
                 num : str,
                 bass : float,
                 vel : float | None = 1,
                 pol : int | None = 2,
                 dis : int | None = 0,
                 eco : int | None = 2,
                 rip_val : int | None = 2
                 ) -> None:
        self.polar = pol
        self.discretion = dis
        self.echo = eco
        self.ripple = rip_val
        self.velocity = vel
        self.base_value = bass
        self.number = num
        self.display = Basal.ct_disp(self)

        if bool(bass == 1) : return ValueError

        if bool(bass > 1):
            if bool(eco != 2):
                num = Basal.unechor(rip_val, num, eco)        

            if bool(pol != 2):
                self.num_value = Basal.polariser(num, bass, pol, vel)
            else:
                self.num_value = Basal.tobasten(num, bass, vel)
        
        else:
            bass = 1 / bass
            num = ''.join(reversed(num))
            if bool(eco != 2):
                num = Basal.unechor(rip_val, num, eco)        

            if bool(pol != 2):
                self.num_value = Basal.polariser(num, bass, pol, vel)
            else:
                self.num_value = Basal.tobasten(num, bass, vel)'''

    def Conv(self, num : int) -> str:
        outout = ''

        if bool(self.base_value == 1) : return ValueError

        if bool(self.base_value > 1):
            outout = Basal.notobasten(num, self.base_value, self.velocity, self.accuracy)
            
            if bool(self.polar != 2):
                outout = Basal.depolaris(outout, self.base_value, self.polar, self.velocity, self.accuracy)

            if bool(self.echo != 2):
                outout = Basal.echor(self.ripple, self.echo, outout)        
        
        else:
            bass = 1 / self.base_value
            num = ''.join(reversed(num))
            outout = Basal.notobasten(num, bass, self.velocity, self.accuracy)

            if bool(self.polar != 2):
                outout = Basal.depolaris(outout, bass, self.polar, self.velocity, self.accuracy)

            if bool(self.echo != 2):
                outout = Basal.echor(self.ripple, self.echo, outout)
        
        return outout

    def Donv(self, num : str) -> float:
        outout = 0

        if bool(self.base_value == 1) : return ValueError

        if bool(self.base_value > 1):
            if bool(self.echo != 2):
                num = Basal.unechor(self.ripple, num, self.echo)        
            
            if bool(self.polar != 2):
                outout = Basal.polariser(num, self.base_value, self.polar, self.velocity)

            else:
                outout = Basal.tobasten(num, self.base_value, self.velocity)
        
        else:
            bass = 1 / self.base_value
            num = ''.join(reversed(num))
            if bool(self.echo != 2):
                num = Basal.unechor(self.ripple, num, self.echo)        
            
            if bool(self.polar != 2):
                outout = Basal.polariser(num, self.base_value, self.polar, self.velocity)

            else:
                outout = Basal.tobasten(num, self.base_value, self.velocity)
        
        return outout 
    
    def Cn(n : str) -> int : return(ord(n) - 48)
    def Vn(n : int) -> str : return(chr(n + 48))

    def tobasten(num : str, bass : float, velocity : float | None = 1) -> float:
        po = 0
        if bool(num[len(num) - 1] == '-'): num = num[1:];  po = 1
        outout = 0;num = ''.join(reversed(num))

        if bool('.' in num):
            pos = num.index('.')
            left =  num[:pos]
            right = num[pos + 1:]        

            for z in range(left.__len__()):
                outout += (bass ** (z * velocity)) * (ord(left[z]) - 48)

            
            for z in range(len(right)):
                outout += (bass ** (0 - ((z + 1) * velocity))) * (ord(right[z]) - 48)

        else:
            for z in range(num.__len__()):          
                outout += (bass ** (z * velocity)) * (ord(num[z]) - 48)


        if bool(po == 0):return outout
        else: return (0-outout)
    def notobasten(num : int, bass : float, velocity : float | None = 1, accuracy : int | None = 30) -> str:
        statis = 0
        if bool(bass < 1) : bass = 1 / bass; statis = 1

        ceil = int(1 + (log(abs(num), (bass ** velocity)) // 1))
        outout = ''

        for z in range(ceil):
            q = (ceil - (z + 1))
            index = bass ** (q * velocity)

            t = int(num // index)

            if bool(t >= 1) : num -= (t * index)
            
            outout += chr(t + 48)        
            
        if bool(num == 0) : 
            if bool(statis == 0): return outout
            else: return '0.' + ''.join(reversed(outout))
        outout += '.'

        for z in range(accuracy - ceil):
            if bool(num == 0) : return outout

            q =  0 - (z + 1)
            index = bass ** (q * velocity)

            t = int(num // index)

            if bool(t >= 1) : num -= (t * index)
            
            outout += chr(t + 48)
        
        if bool(statis == 0): return outout
        else: return ''.join(reversed(outout))

    def polariser(num : str, bass: float, mod : int, velocity : float) -> float:
        outout = float(0)
        l = len(num)
        q = l

        for z in range(l):
            if bool(num[z]   == '.') : continue
            q -= 1
            if bool(q % 2 == mod):
                outout += Basal.Cn(num[z]) * (bass ** (q * velocity))
            else:
                outout -= Basal.Cn(num[z]) * (bass ** (q * velocity))
        
        return outout
    def depolaris(num : str, bass : float, mod : int, velocity : float, accuracy : int | None = 30) -> str:
        albs = 0
        
        x = ''.join(reversed(num))

        z = 0
        if bool('.' in x) : z = x.index('.') - len(x)

        for z_2 in range(len(num)):
            if bool(x[z] == '.') : continue
            if bool(z % 2 != mod):
                if bool(x[z] != '0'):
                    albs += bass ** ((z + 1) * velocity) + (bass - (2 * int(x[z]))) * (bass ** ((z) * velocity))
            z += 1

        return Basal.notobasten(Basal.tobasten(num, bass, velocity) + albs, bass, velocity, accuracy)

    def unechor(ripple : int, num : str, mode : int) -> str:
        r = abs(ripple)
        nlen = len(num) - 1
        try:mid = num.index('জ')
        except:print('Invalid Inputs');exit()
        
        left_arr = [z for z in num[:mid]];left_arr.reverse()
        right_arr = [z for z in num[mid + 1:]]
        fire = 'I'
        rx = rount = len(right_arr)
        lx = lount = len(left_arr)
        out = []

        if bool(ripple < 0):
            right_arr.reverse()
            left_arr.reverse()    
        if bool(mode == 1): fire = '780'

        for z in range(nlen):
            if bool(fire == 'I'):
                for z_2 in range(r):
                    if bool(rx == 0):break

                    out.append(right_arr[rount - rx])
                    rx -= 1
                
                fire = '780'
            
            elif bool(fire == '780'):
                for z_2 in range(r):
                    if bool(lx == 0):break

                    out.append(left_arr[lount - lx])
                    lx -= 1

                fire = 'I'

        outout = ''
        for z in out:
            outout = f"{outout}{z}"

        
        return outout
    def echor(ripple : int, mode : int, num : str) -> str:
        r = ripple
        ripple = abs(ripple)
        left_arr =  []
        right_arr = []
        x = count = len(num)
        fire = 'I'

        if bool(mode == 1):
            fire = '780'

        while bool(x > 0):
            if bool(fire == '780'):fire = 'I'
            elif bool(fire == 'I'):fire = '780'
            else:print('Fatal Error Found, Exiting');exit()

            for z in range(ripple):
                
                if bool(fire == 'I'):
                    pos = count - x
                    if bool(x == 0):break
                    else:
                        left_arr.append(num[pos])

                elif bool(fire == '780'):
                    pos = count - x
                    if bool(x == 0):break
                    else:
                        right_arr.append(num[pos])
                x -= 1            

                if bool(x == 0):break

        if bool(r < 0) : right_arr.reverse()
        else : left_arr.reverse()
            
        return ''.join(left_arr) + "জ" + ''.join(right_arr)

    def ct_disp(self) -> str:
        outout = str(f"<{self.base_value}")
        
        if bool(self.polar != 2):
            if bool(self.polar == 0):
                outout += "ঋ"
            elif bool(self.polar == 1):
                outout += "দ"

        if bool(self.discretion == 0):
            outout += "গ"
        
        if bool(self.echo != 2):
            if bool(self.echo == 0):
                outout += f"+ল{self.ripple}"
            elif bool(self.echo == 1):
                outout += f"-ল{self.ripple}"
        
        if bool(self.velocity != 1):
            outout += f"স{self.velocity}"
        
        return outout + "T"

    def disintegrate(self, noom : str) -> float:
        if bool(self.echo != 2):
            noom = Basal.unechor(self.ripple, noom, self.echo)
        
        if bool(self.polar != 2):
            outout = float(0) ; l = len(noom) ; q = l - 2
            if bool('.' in noom) : q = noom.index('.')

            for z in range(l):
                if bool(noom[z] == '.') : continue
                q -= 1
                if bool(z % 2 == self.polar):
                    outout += Basal.Cn(noom[z]) * Basal.expor(self.base_value, ((q - 1) * self.velocity)) * (q * self.velocity)
                else:
                    outout -= Basal.Cn(noom[z]) * Basal.expor(self.base_value, ((q - 1) * self.velocity)) * (q * self.velocity)
            
            return outout
        
        else:
            po = 0
            if bool(noom[len(noom) - 1] == '-'): noom = noom[1:];  po = 1
            outout = 0

            if bool('.' in noom):
                pos = noom.index('.')
                left = noom[:pos]
                right = noom[pos + 1:] ; left = ''.join(reversed(left))

                for z in range(left.__len__()):
                    outout += Basal.expor(self.base_value, ((z - 1) * self.velocity)) * (ord(left[z]) - 48) * (z * self.velocity)

                
                for z in range(len(right)):
                    outout += Basal.expor(self.base_value, (0 - ((z + 2) * self.velocity))) * (ord(right[z]) - 48) * (0 - ((z + 1) * self.velocity))

            else:
                for z in range(noom.__len__()):          
                    outout += Basal.expor(self.base_value, ((z - 1) * self.velocity)) * (ord(noom[z]) - 48) * (z * self.velocity)


            if bool(po == 0):return outout
            else: return (0-outout)
    def integrate(self, noom : str, C : float | None = 0) -> float:
        if bool(self.echo != 2) : noom = Basal.unechor(self.ripple, noom, self.echo)

        if bool(self.polar != 2):
            outout = float(0) ; l = len(noom) ; q = l - 2

            for z in range(l):
                if bool(noom[z] == '.') : continue
                q -= 1 ; i = 1 + (q * self.velocity)
                if bool(z % 2 == self.polar):outout += noom[z] * Basal.expor(self.base_value, i) / i
                else:outout -= noom[z] * Basal.expor(self.base_value, i) / i

            return outout + C
        
        else:
            po = 0
            if bool(num[len(num) - 1] == '-'): num = num[1:];  po = 1
            outout = 0;num = reversed(num)

            if bool('.' in num):
                pos = num.index('.')
                left = num[:pos] ; right = num[pos + 1:]

                for z in range(len(left)):
                    outout += Basal.expor(self.base_value, ((z + 1) * self.velocity)) * left[z] / (z + 1)

                for z in range(len(right)):
                    outout += Basal.expor(self.base_value, (0 - (z * self.velocity))) * right[z] / z

            else:
                for z in range(len(num)):
                    outout += Basal.expor(self.base_value, ((z + 1) * self.velocity)) * num[z] / (z + 1)
            
            if bool(po == 0):return outout + C
            else: return (0 - outout) - C
            #Not Found

    def expor(num : float, expo : float) -> float:
        if bool(abs(num) != num): 
            if bool(expo % 2 == 1) : return float(num ** expo)
            else : return abs(float(num ** expo))
        else: return float(num ** expo)

    def __int__(self) -> int : return self.num_value    
    def __str__(self) -> str : return str(self.display + " " + self.number)

