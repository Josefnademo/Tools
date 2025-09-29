using System;

class CodeHamming
{
    static void Main()
    {
        Console.WriteLine("Entrez un nombre binaire à 4 bits (par exemple, 1011) :");
        string entree = Console.ReadLine();

        if (entree.Length != 4 || !EstBinaire(entree))
        {
            Console.WriteLine("Entrée incorrecte. Veuillez entrer exactement 4 bits (composés de 0 et 1).");
            return;
        }

        // Convertit l'entrée en un tableau de bits
        int[] bitsDonnees = Array.ConvertAll(entree.ToCharArray(), c => c - '0');
        int[] codeHamming = GenererCodeHamming(bitsDonnees);

        Console.WriteLine("Code Hamming généré :");
        Console.WriteLine(string.Join("", codeHamming));
    }

    // Vérifie si la chaîne contient uniquement 0 et 1
    static bool EstBinaire(string entree)
    {
        foreach (char c in entree)
        {
            if (c != '0' && c != '1')
                return false;
        }
        return true;
    }

    // Génère le code Hamming
    static int[] GenererCodeHamming(int[] bitsDonnees)
    {
        // Code Hamming (7 bits) = 4 bits de données + 3 bits de parité
        int[] codeHamming = new int[7];

        // Place les bits de données aux positions appropriées
        codeHamming[2] = bitsDonnees[0]; // d1
        codeHamming[4] = bitsDonnees[1]; // d2
        codeHamming[5] = bitsDonnees[2]; // d3
        codeHamming[6] = bitsDonnees[3]; // d4

        // Calcule les bits de parité
        codeHamming[0] = codeHamming[2] ^ codeHamming[4] ^ codeHamming[6]; // p1
        codeHamming[1] = codeHamming[2] ^ codeHamming[5] ^ codeHamming[6]; // p2
        codeHamming[3] = codeHamming[4] ^ codeHamming[5] ^ codeHamming[6]; // p4

        return codeHamming;
    }
}
