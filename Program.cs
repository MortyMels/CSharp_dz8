bool r = true; //Число в степени dz5-1 dz6
Console.Clear();
    
while(r){
    Console.WriteLine("Введите набор из трех чисел в формате '0, 0, 0'");
    //string s = Console.ReadLine().Replace(" ", "");
    string s = "2*4*4";
    int[] cl;
    cl=StrToIntAr(s,true);//Вводим размерность массива

    if((cl.Length-1==3)){
        if(cl[0]==0){

            int[][][] arr = new int[cl[1]][][];
            int nz = 3;
            int ns = (int)Math.Pow(10, nz-1);
            int n = ((int)Math.Pow(10, nz)-ns);
            
            int[]narr = new int[n+1];
            for (int i = 0;i<n;i++){
                narr[i]=i+ns;
            }
            if(cl[1]*cl[2]*cl[3]<n){
                for (int i = 0; i < cl[1]; i++){
                    arr[i]=new int[cl[2]][];
                    for (int ii = 0; ii < cl[2]; ii++){
                        arr[i][ii]=new int[cl[3]];
                        for (int iii = 0; iii < cl[3]; iii++){
                        }
                    }
                }

                int xv = 0;
                int yv = 0;
                int zv = 0;
                int xi = 0;
                int yi = 0;
                int zi = 0;
                int xs = cl[3];
                int ys = cl[2];
                int zs = cl[1];
                int rev = 1;


                bool arrend = true;

                arr[zi][yi][xi]+= 1;
                while (arrend){


                    int nr = new Random().Next(0,n);
                    //arr[zi+=zv][yi+=yv][xi+=xv]+= 1;//narr[nr];
                    narr[nr]=narr[n--];
                    //Console.Write($"({xi+1},{yi+1},{zi+1})");
                    Console.Clear();
                    foreach(var arri in arr){
                        foreach(var arrii in arri){
                            Console.WriteLine(string.Join(" ", arrii));
                        }
                        Console.WriteLine("-----");
                    }




                    for (int i = xi+1; i<= xs-yi-1;i++){
                        xi = i;
                        arr[zi][yi][xi]+= 1;
                    }
                    for (int i = yi+1; i<= ys-xs+xi;i++){
                        yi = i;
                        arr[zi][yi][xi]+= 1;
                    }
                    for (int i = xi-1; i>= ys-yi-1;i--){
                        xi = i;
                        arr[zi][yi][xi]+= 1;
                    }
                    for (int i = yi-1; i>= xi;i--){
                        yi = i;
                        if(yi==xi+1){
                            arr[zi][yi][xi]+= 1;
                            if(zi+rev==zs|zi+rev==-1){
                                rev*=-1;
                                i--;
                            }else{
                                zi+=rev;
                            }
                            
                        }else{
                            arr[zi][yi][xi]+= 1;
                        }
                    }
                }
            }else{
                Console.WriteLine($"Количество доступных уникальных значений меньше чем размер массива: {s}");
            }
        }
    }else{
        Console.WriteLine($"Неверное количество параметров в наборе чисел: {s}");
    }
    if (s=="end"){
        r=false;
    }
    
}

int[] StrToIntAr(string str, bool err) {
    string[] stra = str.Split(',','*');
    int[] numa = new int [stra.Length+1];
    int i = 0;
    foreach (string strai in stra){
        if(!int.TryParse(strai, out numa[++i])){
            if(err){
                Console.WriteLine($"Нераспознан {i} элемента набора '{strai}' в: {str}");
            }
            numa[0]++;
        }
    }
    return numa;
}