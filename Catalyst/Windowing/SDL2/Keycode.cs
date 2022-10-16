using System;

namespace Catalyst.Windowing.SDL2
{
    internal static unsafe partial class SDL
    {
        internal const int SDLK_MASK = 1 << 30;
    }

    public enum Keycode
    {
        Unknown = 0,

        Return = '\r',
        Escape = 27,
        Backspace = '\b',
        Tab = '\t',
        Space = ' ',
        Exclaim = '!',
        Quotedbl = '"',
        Hash = '#',
        Percent = '%',
        Dollar = '$',
        Ampersand = '&',
        Quote = '\'',
        LeftParen = '(',
        RightParen = ')',
        Asterisk = '*',
        Plus = '+',
        Comma = ',',
        Minus = '-',
        Period = '.',
        Slash = '/',
        D0 = '0',
        D1 = '1',
        D2 = '2',
        D3 = '3',
        D4 = '4',
        D5 = '5',
        D6 = '6',
        D7 = '7',
        D8 = '8',
        D9 = '9',
        Colon = ':',
        SemiColon = ';',
        Less = '<',
        Equals = '=',
        Greater = '>',
        Question = '?',
        At = '@',

        /*
           Skip uppercase letters
         */
        LeftBracket = '[',
        Backslash = '\\',
        RightBracket = ']',
        Caret = '^',
        Underscore = '_',
        BackQuote = '`',
        A = 'a',
        B = 'b',
        C = 'c',
        D = 'd',
        E = 'e',
        F = 'f',
        G = 'g',
        H = 'h',
        I = 'i',
        J = 'j',
        K = 'k',
        L = 'l',
        M = 'm',
        N = 'n',
        O = 'o',
        P = 'p',
        Q = 'q',
        R = 'r',
        S = 's',
        T = 't',
        U = 'u',
        V = 'v',
        W = 'w',
        X = 'x',
        Y = 'y',
        Z = 'z',

        CapsLock = Scancode.CapsLock | Windowing.SDL2.SDL.SDLK_MASK,

        F1 = Scancode.F1 | Windowing.SDL2.SDL.SDLK_MASK,
        F2 = Scancode.F2 | Windowing.SDL2.SDL.SDLK_MASK,
        F3 = Scancode.F3 | Windowing.SDL2.SDL.SDLK_MASK,
        F4 = Scancode.F4 | Windowing.SDL2.SDL.SDLK_MASK,
        F5 = Scancode.F5 | Windowing.SDL2.SDL.SDLK_MASK,
        F6 = Scancode.F6 | Windowing.SDL2.SDL.SDLK_MASK,
        F7 = Scancode.F7 | Windowing.SDL2.SDL.SDLK_MASK,
        F8 = Scancode.F8 | Windowing.SDL2.SDL.SDLK_MASK,
        F9 = Scancode.F9 | Windowing.SDL2.SDL.SDLK_MASK,
        F10 = Scancode.F10 | Windowing.SDL2.SDL.SDLK_MASK,
        F11 = Scancode.F11 | Windowing.SDL2.SDL.SDLK_MASK,
        F12 = Scancode.F12 | Windowing.SDL2.SDL.SDLK_MASK,

        PrintScreen = Scancode.PrintScreen | Windowing.SDL2.SDL.SDLK_MASK,
        ScrollLock = Scancode.ScrollLock | Windowing.SDL2.SDL.SDLK_MASK,
        Pause = Scancode.Pause | Windowing.SDL2.SDL.SDLK_MASK,
        Insert = Scancode.Insert | Windowing.SDL2.SDL.SDLK_MASK,
        Home = Scancode.Home | Windowing.SDL2.SDL.SDLK_MASK,
        PageUp = Scancode.PageUp | Windowing.SDL2.SDL.SDLK_MASK,
        Delete = 127,
        End = Scancode.End | Windowing.SDL2.SDL.SDLK_MASK,
        PageDown = Scancode.PageDown | Windowing.SDL2.SDL.SDLK_MASK,
        Right = Scancode.Right | Windowing.SDL2.SDL.SDLK_MASK,
        Left = Scancode.Left | Windowing.SDL2.SDL.SDLK_MASK,
        Down = Scancode.Down | Windowing.SDL2.SDL.SDLK_MASK,
        Up = Scancode.Up | Windowing.SDL2.SDL.SDLK_MASK,

        NumLockClear = Scancode.NumLockClear | Windowing.SDL2.SDL.SDLK_MASK,
        KeyPadDivide = Scancode.KeyPadDivide | Windowing.SDL2.SDL.SDLK_MASK,
        KeyPadMultiply = Scancode.KeyPadMultiply | Windowing.SDL2.SDL.SDLK_MASK,
        KeyPadMinus = Scancode.KeyPadMinus | Windowing.SDL2.SDL.SDLK_MASK,
        KeyPadPlus = Scancode.KeyPadPlus | Windowing.SDL2.SDL.SDLK_MASK,
        KeyPadEnter = Scancode.KeyPadEnter | Windowing.SDL2.SDL.SDLK_MASK,
        KeyPad1 = Scancode.KeyPad1 | Windowing.SDL2.SDL.SDLK_MASK,
        KeyPad2 = Scancode.KeyPad2 | Windowing.SDL2.SDL.SDLK_MASK,
        KeyPad3 = Scancode.KeyPad3 | Windowing.SDL2.SDL.SDLK_MASK,
        KeyPad4 = Scancode.KeyPad4 | Windowing.SDL2.SDL.SDLK_MASK,
        KeyPad5 = Scancode.KeyPad5 | Windowing.SDL2.SDL.SDLK_MASK,
        KeyPad6 = Scancode.KeyPad6 | Windowing.SDL2.SDL.SDLK_MASK,
        KeyPad7 = Scancode.KeyPad7 | Windowing.SDL2.SDL.SDLK_MASK,
        KeyPad8 = Scancode.KeyPad8 | Windowing.SDL2.SDL.SDLK_MASK,
        KeyPad9 = Scancode.KeyPad9 | Windowing.SDL2.SDL.SDLK_MASK,
        KeyPad0 = Scancode.KeyPad0 | Windowing.SDL2.SDL.SDLK_MASK,
        KeyPadPeriod = Scancode.KeyPadPeriod | Windowing.SDL2.SDL.SDLK_MASK,

        Application = Scancode.Application | Windowing.SDL2.SDL.SDLK_MASK,
        Power = Scancode.Power | Windowing.SDL2.SDL.SDLK_MASK,
        KeyPadEquals = Scancode.KeyPadEquals | Windowing.SDL2.SDL.SDLK_MASK,
        F13 = Scancode.F13 | Windowing.SDL2.SDL.SDLK_MASK,
        F14 = Scancode.F14 | Windowing.SDL2.SDL.SDLK_MASK,
        F15 = Scancode.F15 | Windowing.SDL2.SDL.SDLK_MASK,
        F16 = Scancode.F16 | Windowing.SDL2.SDL.SDLK_MASK,
        F17 = Scancode.F17 | Windowing.SDL2.SDL.SDLK_MASK,
        F18 = Scancode.F18 | Windowing.SDL2.SDL.SDLK_MASK,
        F19 = Scancode.F19 | Windowing.SDL2.SDL.SDLK_MASK,
        F20 = Scancode.F20 | Windowing.SDL2.SDL.SDLK_MASK,
        F21 = Scancode.F21 | Windowing.SDL2.SDL.SDLK_MASK,
        F22 = Scancode.F22 | Windowing.SDL2.SDL.SDLK_MASK,
        F23 = Scancode.F23 | Windowing.SDL2.SDL.SDLK_MASK,
        F24 = Scancode.F24 | Windowing.SDL2.SDL.SDLK_MASK,
        Execute = Scancode.Execute | Windowing.SDL2.SDL.SDLK_MASK,
        Help = Scancode.Help | Windowing.SDL2.SDL.SDLK_MASK,
        Menu = Scancode.Menu | Windowing.SDL2.SDL.SDLK_MASK,
        Select = Scancode.Select | Windowing.SDL2.SDL.SDLK_MASK,
        Stop = Scancode.Stop | Windowing.SDL2.SDL.SDLK_MASK,
        Again = Scancode.Again | Windowing.SDL2.SDL.SDLK_MASK,
        Undo = Scancode.Undo | Windowing.SDL2.SDL.SDLK_MASK,
        Cut = Scancode.Cut | Windowing.SDL2.SDL.SDLK_MASK,
        Copy = Scancode.Copy | Windowing.SDL2.SDL.SDLK_MASK,
        Paste = Scancode.Paste | Windowing.SDL2.SDL.SDLK_MASK,
        Find = Scancode.Find | Windowing.SDL2.SDL.SDLK_MASK,
        Mute = Scancode.Mute | Windowing.SDL2.SDL.SDLK_MASK,
        VolumeUp = Scancode.VolumeUp | Windowing.SDL2.SDL.SDLK_MASK,
        VolumeDown = Scancode.VolumeDown | Windowing.SDL2.SDL.SDLK_MASK,
        KeyPadComma = Scancode.KeyPadComma | Windowing.SDL2.SDL.SDLK_MASK,
        KeyPadEqualsAS400 = Scancode.KeyPadEqualsAS400 | Windowing.SDL2.SDL.SDLK_MASK,

        AltErase = Scancode.AltErase | Windowing.SDL2.SDL.SDLK_MASK,
        SysReq = Scancode.SysReq | Windowing.SDL2.SDL.SDLK_MASK,
        Cancel = Scancode.Cancel | Windowing.SDL2.SDL.SDLK_MASK,
        Clear = Scancode.Clear | Windowing.SDL2.SDL.SDLK_MASK,
        Prior = Scancode.Prior | Windowing.SDL2.SDL.SDLK_MASK,
        Return2 = Scancode.Return2 | Windowing.SDL2.SDL.SDLK_MASK,
        Separator = Scancode.Separator | Windowing.SDL2.SDL.SDLK_MASK,
        Out = Scancode.Out | Windowing.SDL2.SDL.SDLK_MASK,
        Oper = Scancode.Oper | Windowing.SDL2.SDL.SDLK_MASK,
        ClearAgain = Scancode.ClearAgain | Windowing.SDL2.SDL.SDLK_MASK,
        CrSel = Scancode.CrSel | Windowing.SDL2.SDL.SDLK_MASK,
        ExSel = Scancode.ExSel | Windowing.SDL2.SDL.SDLK_MASK,

        KeyPad00 = Scancode.KeyPad00 | Windowing.SDL2.SDL.SDLK_MASK,
        KeyPad000 = Scancode.KeyPad000 | Windowing.SDL2.SDL.SDLK_MASK,
        ThousandsSeparator = Scancode.ThousandsSeparator | Windowing.SDL2.SDL.SDLK_MASK,
        DecimalSeparator = Scancode.DecimalSeparator | Windowing.SDL2.SDL.SDLK_MASK,
        CurrencyUnit = Scancode.CurrencyUnit | Windowing.SDL2.SDL.SDLK_MASK,
        CurrencySubunit = Scancode.CurrencySubunit | Windowing.SDL2.SDL.SDLK_MASK,
        KeyPadLeftParen = Scancode.KeyPadLeftParen | Windowing.SDL2.SDL.SDLK_MASK,
        KeyPadRightParen = Scancode.KeyPadRightParen | Windowing.SDL2.SDL.SDLK_MASK,
        KeyPadLeftBrace = Scancode.KeyPadLeftBrace | Windowing.SDL2.SDL.SDLK_MASK,
        KeyPadRightBrace = Scancode.KeyPadRightBrace | Windowing.SDL2.SDL.SDLK_MASK,
        KeyPadTab = Scancode.KeyPadTab | Windowing.SDL2.SDL.SDLK_MASK,
        KeyPadBackspace = Scancode.KeyPadBackspace | Windowing.SDL2.SDL.SDLK_MASK,
        KeyPadA = Scancode.KeyPadA | Windowing.SDL2.SDL.SDLK_MASK,
        KeyPadB = Scancode.KeyPadB | Windowing.SDL2.SDL.SDLK_MASK,
        KeyPadC = Scancode.KeyPadC | Windowing.SDL2.SDL.SDLK_MASK,
        KeyPadD = Scancode.KeyPadD | Windowing.SDL2.SDL.SDLK_MASK,
        KeyPadE = Scancode.KeyPadE | Windowing.SDL2.SDL.SDLK_MASK,
        KeyPadF = Scancode.KeyPadF | Windowing.SDL2.SDL.SDLK_MASK,
        KeyPadXor = Scancode.KeyPadXor | Windowing.SDL2.SDL.SDLK_MASK,
        KeyPadPower = Scancode.KeyPadPower | Windowing.SDL2.SDL.SDLK_MASK,
        KeyPadPercent = Scancode.KeyPadPercent | Windowing.SDL2.SDL.SDLK_MASK,
        KeyPadLess = Scancode.KeyPadLess | Windowing.SDL2.SDL.SDLK_MASK,
        KeyPadGreater = Scancode.KeyPadGreater | Windowing.SDL2.SDL.SDLK_MASK,
        KeyPadAmpersand = Scancode.KeyPadAmpersand | Windowing.SDL2.SDL.SDLK_MASK,
        KeyPadDoubleAmpersand = Scancode.KeyPadDoubleAmpersand | Windowing.SDL2.SDL.SDLK_MASK,
        KeyPadVerticalBar = Scancode.KeyPadVerticalBar | Windowing.SDL2.SDL.SDLK_MASK,
        KeyPadDoubleVerticalBar = Scancode.KeyPadDoubleVerticalBar | Windowing.SDL2.SDL.SDLK_MASK,
        KeyPadColon = Scancode.KeyPadColon | Windowing.SDL2.SDL.SDLK_MASK,
        KeyPadHash = Scancode.KeyPadHash | Windowing.SDL2.SDL.SDLK_MASK,
        KeyPadSpace = Scancode.KeyPadSpace | Windowing.SDL2.SDL.SDLK_MASK,
        KeyPadAt = Scancode.KeyPadAt | Windowing.SDL2.SDL.SDLK_MASK,
        KeyPadExclam = Scancode.KeyPadExclam | Windowing.SDL2.SDL.SDLK_MASK,
        KeyPadMemStore = Scancode.KeyPadMemStore | Windowing.SDL2.SDL.SDLK_MASK,
        KeyPadMemRecall = Scancode.KeyPadMemRecall | Windowing.SDL2.SDL.SDLK_MASK,
        KeyPadMemClear = Scancode.KeyPadMemClear | Windowing.SDL2.SDL.SDLK_MASK,
        KeyPadMemAdd = Scancode.KeyPadMemAdd | Windowing.SDL2.SDL.SDLK_MASK,
        KeyPadMemSubtract = Scancode.KeyPadMemSubtract | Windowing.SDL2.SDL.SDLK_MASK,
        KeyPadMemMultiply = Scancode.KeyPadMemMultiply | Windowing.SDL2.SDL.SDLK_MASK,
        KeyPadMemDivide = Scancode.KeyPadMemDivide | Windowing.SDL2.SDL.SDLK_MASK,
        KeyPadPlusMinus = Scancode.KeyPadPlusMinus | Windowing.SDL2.SDL.SDLK_MASK,
        KeyPadClear = Scancode.KeyPadClear | Windowing.SDL2.SDL.SDLK_MASK,
        KeyPadClearEntry = Scancode.KeyPadClearEntry | Windowing.SDL2.SDL.SDLK_MASK,
        KeyPadBinary = Scancode.KeyPadBinary | Windowing.SDL2.SDL.SDLK_MASK,
        KeyPadOctal = Scancode.KeyPadOctal | Windowing.SDL2.SDL.SDLK_MASK,
        KeyPadDecimal = Scancode.KeyPadDecimal | Windowing.SDL2.SDL.SDLK_MASK,
        KeyPadHexadecimal = Scancode.KeyPadHexadecimal | Windowing.SDL2.SDL.SDLK_MASK,

        LCtrl = Scancode.LCtrl | Windowing.SDL2.SDL.SDLK_MASK,
        LShift = Scancode.LShift | Windowing.SDL2.SDL.SDLK_MASK,
        LAlt = Scancode.LAlt | Windowing.SDL2.SDL.SDLK_MASK,
        LGui = Scancode.LGui | Windowing.SDL2.SDL.SDLK_MASK,
        RCtrl = Scancode.RCtrl | Windowing.SDL2.SDL.SDLK_MASK,
        RShift = Scancode.RShift | Windowing.SDL2.SDL.SDLK_MASK,
        RAlt = Scancode.RAlt | Windowing.SDL2.SDL.SDLK_MASK,
        RGui = Scancode.RGui | Windowing.SDL2.SDL.SDLK_MASK,

        Mode = Scancode.Mode | Windowing.SDL2.SDL.SDLK_MASK,

        AudioNext = Scancode.AudioNext | Windowing.SDL2.SDL.SDLK_MASK,
        AudioPrev = Scancode.AudioPrev | Windowing.SDL2.SDL.SDLK_MASK,
        AudioStop = Scancode.AudioStop | Windowing.SDL2.SDL.SDLK_MASK,
        AudioPlay = Scancode.AudioPlay | Windowing.SDL2.SDL.SDLK_MASK,
        AudioMute = Scancode.AudioMute | Windowing.SDL2.SDL.SDLK_MASK,
        MediaSelect = Scancode.MediaSelect | Windowing.SDL2.SDL.SDLK_MASK,
        Www = Scancode.Www | Windowing.SDL2.SDL.SDLK_MASK,
        Mail = Scancode.Mail | Windowing.SDL2.SDL.SDLK_MASK,
        Calculator = Scancode.Calculator | Windowing.SDL2.SDL.SDLK_MASK,
        Computer = Scancode.Computer | Windowing.SDL2.SDL.SDLK_MASK,
        AcSearch = Scancode.AcSearch | Windowing.SDL2.SDL.SDLK_MASK,
        AcHome = Scancode.AcHome | Windowing.SDL2.SDL.SDLK_MASK,
        AcBack = Scancode.AcBack | Windowing.SDL2.SDL.SDLK_MASK,
        AcForward = Scancode.AcForward | Windowing.SDL2.SDL.SDLK_MASK,
        AcStop = Scancode.AcStop | Windowing.SDL2.SDL.SDLK_MASK,
        AcRefresh = Scancode.AcRefresh | Windowing.SDL2.SDL.SDLK_MASK,
        AcBookmarks = Scancode.AcBookmarks | Windowing.SDL2.SDL.SDLK_MASK,

        BrightnessDown = Scancode.BrightnessDown | Windowing.SDL2.SDL.SDLK_MASK,
        BrightnessUp = Scancode.BrightnessUp | Windowing.SDL2.SDL.SDLK_MASK,
        DisplaySwitch = Scancode.DisplaySwitch | Windowing.SDL2.SDL.SDLK_MASK,
        KbdIllumToggle = Scancode.KbdIllumToggle | Windowing.SDL2.SDL.SDLK_MASK,
        KbdIllumDown = Scancode.KbdIllumDown | Windowing.SDL2.SDL.SDLK_MASK,
        KbdIllumUp = Scancode.KbdIllumUp | Windowing.SDL2.SDL.SDLK_MASK,
        Eject = Scancode.Eject | Windowing.SDL2.SDL.SDLK_MASK,
        Sleep = Scancode.Sleep | Windowing.SDL2.SDL.SDLK_MASK,
        App1 = Scancode.App1 | Windowing.SDL2.SDL.SDLK_MASK,
        App2 = Scancode.App2 | Windowing.SDL2.SDL.SDLK_MASK,

        AudioRewind = Scancode.AudioRewind | Windowing.SDL2.SDL.SDLK_MASK,
        AudioFastForward = Scancode.AudioFastForward | Windowing.SDL2.SDL.SDLK_MASK
    }

    [Flags]
    public enum KeyModifier : ushort
    {
        None = 0x0000,
        LeftShift = 0x0001,
        RightShift = 0x0002,
        LeftCtrl = 0x0040,
        RightCtrl = 0x0080,
        LeftAlt = 0x0100,
        RightAlt = 0x0200,
        LeftGui = 0x0400,
        RightGui = 0x0800,
        Num = 0x1000,
        Caps = 0x2000,
        Mode = 0x4000,
        Reserved = 0x8000,

        Ctrl = LeftCtrl | RightCtrl,
        Shift = LeftShift | RightShift,
        Alt = LeftAlt | RightAlt,
        Gui = LeftGui | RightGui
    }
}