////////////////////////////////////////
//
//   Љубомир Мићић
//   Понедељак, 9. јануар 2022.
//
////////////////////////////////////////

using Project.Time;

namespace Project {
  public static class About {
    public static void main(string[] args) {
      Console.WriteLine("Програм направљен за матурски испит.\nОвај део је добар с тим што IDE који користим прави нелогичне багове које бих додатно требао да исправљам. Он је и схифар.\nПрелазим на Visual Studio.");
      Time.Forward(96); // in days
      Console.WriteLine("Завршен пројекат");
    }
  }
}
