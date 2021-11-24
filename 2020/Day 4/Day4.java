import java.io.File;
import java.io.FileNotFoundException;
import java.util.HashSet;
import java.util.HashMap;
import java.util.Scanner;

class Day4 {
    private void part_one(Scanner sc, HashSet<String> pass, int valid) {        
        while (sc.hasNextLine()) {
            String s = sc.nextLine();

            if (s.equals("")) {
                if (pass.size() == 8 || (pass.size() == 7 && !pass.contains("cid"))) {
                    valid++;
                }
                pass = new HashSet<String>();
                continue;
            }

            for (String st : s.split(" ")) {
                pass.add(st.split(":")[0]);
            }
        }
        System.out.println(valid);
    }


    private void part_two(Scanner sc, HashMap<String, String> pass, int valid) {
        // Learn RegEx
        System.out.println(valid);
    }


    public static void main(String[] args) throws FileNotFoundException {
        Scanner sc = new Scanner(new File("input.txt"));
        new Day4().part_one(sc, new HashSet<String>(), 0);
        new Day4().part_two(sc, new HashMap<String, String>(), 0);
        sc.close();
    }
}