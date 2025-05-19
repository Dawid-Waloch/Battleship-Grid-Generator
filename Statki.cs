using System;
class HelloWorld {
    static void Main() {
        
        Random rand = new Random();
        int[,] plansza = new int[12, 12];
        int standardowa_szerokosc_x = 10;
        int standardowa_szerokosc_y = 10;

        int v = standardowa_szerokosc_y;
        int h = standardowa_szerokosc_x;
        
        for(int i = 0; i < v; i++) {
            for(int j = 0; j < h; j++) {
                plansza[i, j] = 0;
            }
        }
        
        int licznik = 1;
        int masztowiec = 4;
        
        while(masztowiec >= 1) {
            for(int i = 0; i < licznik; i++) {
                
                bool statekUstawiony = false;
                
                while(!statekUstawiony) {
                    int pozycjaX = rand.Next(1,10);
                    int pozycjaY = rand.Next(1,10);
                    int kierunek = rand.Next(1,5);
                    
                    if(CzyDaSieUstawic(plansza, pozycjaX, pozycjaY, kierunek, masztowiec)) {
                        UstawStatek(plansza, pozycjaX, pozycjaY, kierunek, masztowiec);
                        statekUstawiony = true;
                    }
                }
            }
            
            licznik++;
            masztowiec--;
        }
        
        for(int i = 0; i < v; i++) {
            for(int j = 0; j < h; j++) {
                if(plansza[i, j] == 2) {
                    Console.Write("0 ");
                } else {
                    Console.Write(plansza[i, j] + " ");
                }
            }
            Console.WriteLine();
        }
    }
    
    public static bool CzyDaSieUstawic(int[,] plansza, int x, int y, int kierunek, int dlugosc) {
        int v = 10;
        int h = 10;
        
        for(int i = 0; i < dlugosc; i++) {
            int temp_x = x;
            int temp_y = y;
            
            switch(kierunek) {
                case 1:
                {
                    temp_x = x - i;
                    break;
                }
                case 2:
                {
                    temp_x = x + i;
                    break;
                }
                case 3:
                {
                    temp_y = y + i;
                    break;
                }
                case 4:
                {
                    temp_y = y - i;
                    break;
                }
            }
            
            if(temp_x < 0 || temp_x >= h || temp_y < 0 || temp_y >= v || plansza[temp_y, temp_x] != 0) {
                return false;
            }
        }
        return true;
    }
    
    public static void UstawStatek(int[,] plansza, int x, int y, int kierunek, int dlugosc) {
        
        int temp_x = x;
        int temp_y = y;
        int jeden_bok = 0, drugi_bok = 0, przod = 0, tyl = 0;
        
        for(int i = 0; i < dlugosc; i++) {
            temp_x = x;
            temp_y = y;
            
            switch(kierunek) {
                case 1:
                {
                    temp_x = x - i;
                    tyl = x + 1;
                    przod = x - dlugosc;
                    jeden_bok = y + 1;
                    drugi_bok = y - 1;
                    
                    break;
                }
                case 2:
                {
                    temp_x = x + i;
                    tyl = x - 1;
                    jeden_bok = y + 1;
                    drugi_bok = y - 1;
                    przod = x + dlugosc;
                    break;
                }
                case 3:
                {
                    temp_y = y + i;
                    tyl = y - 1;
                    przod = y + dlugosc;
                    jeden_bok = x + 1;
                    drugi_bok = x - 1;
                    break;
                }
                case 4:
                {
                    temp_y = y - i;
                    tyl = y + 1;
                    przod = y - dlugosc;
                    jeden_bok = x + 1;
                    drugi_bok = x - 1;
                    break;
                }
            }
            
            plansza[temp_y, temp_x] = 1;
            if(kierunek == 1 || kierunek == 2) {
                plansza[jeden_bok, temp_x] = 2;
                plansza[drugi_bok, temp_x] = 2;
            } else {
                plansza[temp_y, jeden_bok] = 2;
                plansza[temp_y, drugi_bok] = 2;
            }
             
        }
        
        if(kierunek == 1 || kierunek == 2) {
            if(przod >= 0 && przod < 10 && tyl >= 0 && tyl < 10) {
                plansza[temp_y, tyl] = 2;
                plansza[temp_y, przod] = 2;
            }
        } else {
            if(przod >= 0 && przod < 10 && tyl >= 0 && tyl < 10) {
                plansza[tyl, temp_x] = 2;
                plansza[przod, temp_x] = 2;
            }
        }
    }     
}
