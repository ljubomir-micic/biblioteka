////////////////////////////////////////////////////////////
//
//    Библиотека
//    Copyright © 2022-2023 Љубомир Мићић
//    Сва права су заштићена.
//
////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;

namespace Project {
    public interface Iid {
        int AutoIncrementInt();
        int RandomInt();
        int preuzmiID();
    }
}